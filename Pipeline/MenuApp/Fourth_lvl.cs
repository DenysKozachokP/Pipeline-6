using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApp
{
    public partial class Fourth_lvl : Form
    {
        private SoundPlayer[] players;
        private Fourthlvl fourthlvl = new Fourthlvl();
        private Result_base result_base = new Result_base();
        private FinishAnimation animation = new FinishAnimation();
        private Stopwatch stopwatch = new Stopwatch();

        public Fourth_lvl()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitializeSoundPlayers();
            this.Refresh();
        }

        private void InitializeSoundPlayers()
        {
            players = new SoundPlayer[3];
            int soundInfo = result_base.GetSoundInfo();

            players[0] = result_base.GetSuond(soundInfo == 1 ? 2 : 4);
            players[1] = result_base.GetSuond(soundInfo == 1 ? 3 : 4);
            players[2] = result_base.GetSuond(soundInfo == 1 ? 1 : 4);
        }

        private void LoseAnimation()
        {
            var loseForm = new LoseForm();
            loseForm.SetStar(4);
            loseForm.Show();
            this.Hide();
        }

        private void FinishAnimation()
        {
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            label1.Refresh();
            players[2].Play();
            Thread.Sleep(300);
            stopwatch.Stop();
            players[1].Play();
            Thread.Sleep(3000);

            int duration = (int)stopwatch.Elapsed.TotalSeconds;
            Form_result form_result = new Form_result();
            form_result.SetStar(fourthlvl.GetStars(), fourthlvl.GetCountStar(), 5);

            UpdateResultBase(duration);

            PictureBox[] pictureBoxes = { pictureBox3, pictureBox4, pictureBox5, pictureBox6,
                                          pictureBox7, pictureBox8, pictureBox10, pictureBox12,
                                          pictureBox9, pictureBox11, pictureBox13, pictureBox14,
                                          pictureBox15, pictureBox17, pictureBox18 };
            int[] fina = { 8, 2, 0, 1, 10, 3, 8, 8, 1, 7, 2, 0, 2, 0, 11 };

            players[0].Play();
            animation.FinishAnim(pictureBoxes, fina);
            players[0].Stop();

            form_result.Show();
            this.Hide();
        }

        private void UpdateResultBase(int duration)
        {
            int[] result_arr = result_base.GetResultArray();
            int currentStars = fourthlvl.GetStars();
            int currentCountStar = fourthlvl.GetCountStar();

            if (result_arr.Length >= 12)
            {
                int previousCountStar = result_arr[10];
                int previousDuration = result_arr[11];

                if (currentCountStar < previousCountStar || (currentCountStar == previousCountStar && previousDuration > duration))
                {
                    result_base.ChangeInfoToBase(9, currentStars, currentCountStar, duration);
                }
            }
            else if (result_arr.Length == 9)
            {
                result_base.SetInfoToBase(currentStars, currentCountStar, duration);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int index = int.Parse(pictureBox.Tag.ToString());
            players[2].Play();

            switch (index)
            {
                case 0:
                case 1:
                case 3:
                case 4:
                case 7:
                case 8:
                case 9:
                case 10:
                    fourthlvl.Rotate90Deg(pictureBox, index);
                    fourthlvl.CountDegrysZH4(index);
                    break;
                case 2:
                case 5:
                case 6:
                    fourthlvl.Rotate90Deg(pictureBox, index);
                    fourthlvl.CountDegrysPR4(index);
                    break;
            }

            if (fourthlvl.GetFinishmark())
                FinishAnimation();

            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void PictureBox_Star_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox_Menu_Click(object sender, EventArgs e)
        {
            Form_Menu form_menu = new Form_Menu();
            form_menu.Show();
            this.Hide();
        }

        private void pictureBox_Reload_Click(object sender, EventArgs e)
        {
            Fourth_lvl fourth_lvl = new Fourth_lvl();
            fourth_lvl.Show();
            this.Hide();
        }

        private void pictureBox_LevelMenu_Click(object sender, EventArgs e)
        {
            Level_Menu level_menu = new Level_Menu();
            level_menu.Show();
            this.Hide();
        }

        private void Fourth_lvl_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            Form_Menu form_menu = Application.OpenForms["Form_Menu"] as Form_Menu;
            if (form_menu != null)
            {
                players[0] = form_menu.GetSoundPlayer();
                if (players[0] != null)
                {
                    players[0].Stop();
                }
            }
        }
    }
}
