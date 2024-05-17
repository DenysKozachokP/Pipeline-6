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

            PictureBox[] pictureBoxes = {
            pictureBox3 , pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8,
            pictureBox10, pictureBox12, pictureBox9, pictureBox11, pictureBox13, pictureBox14,
            pictureBox15, pictureBox17, pictureBox18
        };
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox4, 0);
            fourthlvl.CountDegrysZH4(0);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox5, 1);
            fourthlvl.CountDegrysZH4(1);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox3, 2);
            fourthlvl.CountDegrysPR4(2);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox6, 3);
            fourthlvl.CountDegrysZH4(3);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox8, 4);
            fourthlvl.CountDegrysZH4(4);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox10, 5);
            fourthlvl.CountDegrysPR4(5);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox12, 6);
            fourthlvl.CountDegrysPR4(6);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox9, 7);
            fourthlvl.CountDegrysZH4(7);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox11, 8);
            fourthlvl.CountDegrysZH4(8);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox14, 9);
            fourthlvl.CountDegrysZH4(9);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox13, 10);
            fourthlvl.CountDegrysZH4(10);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox15, 11);
            fourthlvl.CountDegrysZH4(11);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            players[2].Play();
            fourthlvl.Rotate90Deg(pictureBox17, 12);
            fourthlvl.CountDegrysZH4(12);
            if (fourthlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox19.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox19.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox20.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox20.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox21.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox21.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox22.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox22.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox16.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox16.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox23.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox23.Refresh();
            fourthlvl.CountStarPlus();
            label1.Text = (31 - fourthlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Form_Menu form_menu = new Form_Menu();
            form_menu.Show();
            this.Hide();
        }
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Fourth_lvl fourth_lvl = new Fourth_lvl();
            fourth_lvl.Show();
            this.Hide();
        }
        private void pictureBox24_Click(object sender, EventArgs e)
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
