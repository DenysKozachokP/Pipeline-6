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
    public partial class Third_lvl : Form
    {
        private SoundPlayer[] players;
        private Thirdlvl thirdlvl = new Thirdlvl();
        private Result_base result_base = new Result_base();
        private FinishAnimation animation = new FinishAnimation();
        private Stopwatch stopwatch = new Stopwatch();

        public Third_lvl()
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
            loseForm.SetStar(3);
            loseForm.Show();
            this.Hide();
        }

        private void FinishAnimation()
        {
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            label1.Refresh();
            players[2].Play();
            Thread.Sleep(300);
            stopwatch.Stop();
            players[1].Play();
            Thread.Sleep(3000);

            int duration = (int)stopwatch.Elapsed.TotalSeconds;
            Form_result form_result = new Form_result();
            form_result.SetStar(thirdlvl.GetStars(), thirdlvl.GetCountStar(), 4);

            UpdateResultBase(duration);

            PictureBox[] pictureBoxes = {
            pictureBox4, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
            pictureBox14, pictureBox15, pictureBox13, pictureBox19, pictureBox16, pictureBox17,
            pictureBox21, pictureBox18, pictureBox20, pictureBox2, pictureBox3
        };
            int[] fina = { 2, 0, 7, 0, 8, 1, 3, 8, 8, 8, 1, 3, 1, 8, 3, 11, 11 };

            players[0].Play();
            animation.FinishAnim(pictureBoxes, fina);
            players[0].Stop();

            form_result.Show();
            this.Hide();
        }

        private void UpdateResultBase(int duration)
        {
            int[] result_arr = result_base.GetResultArray();
            int currentStars = thirdlvl.GetStars();
            int currentCountStar = thirdlvl.GetCountStar();

            if (result_arr.Length >= 9)
            {
                int previousCountStar = result_arr[7];
                int previousDuration = result_arr[8];

                if (currentCountStar < previousCountStar || (currentCountStar == previousCountStar && previousDuration > duration))
                {
                    result_base.ChangeInfoToBase(6, currentStars, currentCountStar, duration);
                }
            }
            else if (result_arr.Length == 6)
            {
                result_base.SetInfoToBase(currentStars, currentCountStar, duration);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox4, 0);
            thirdlvl.CountDegrysZH3(0);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox6, 1);
            thirdlvl.CountDegrysZH3(1);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox7, 2);
            thirdlvl.CountDegrysZH3(2);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox8, 3);
            thirdlvl.CountDegrysZH3(3);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox10, 4);
            thirdlvl.CountDegrysZH3(4);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox9, 5);
            thirdlvl.CountDegrysPR3(5);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox13, 6);
            thirdlvl.CountDegrysPR3(6);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox19, 7);
            thirdlvl.CountDegrysPR3(7);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox21, 8);
            thirdlvl.CountDegrysZH3(8);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox20, 9);
            thirdlvl.CountDegrysZH3(9);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox14, 10);
            thirdlvl.CountDegrysZH3(10);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox15, 11);
            thirdlvl.CountDegrysPR3(11);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox16, 12);
            thirdlvl.CountDegrysZH3(12);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox17, 13);
            thirdlvl.CountDegrysZH3(13);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            players[2].Play();
            thirdlvl.Rotate90Deg(pictureBox18, 14);
            thirdlvl.CountDegrysPR3(14);
            if (thirdlvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox11.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox11.Refresh();
            thirdlvl.CountStarPlus();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox12.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox12.Refresh();
            thirdlvl.CountStarPlus();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox5.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox5.Refresh();
            thirdlvl.CountStarPlus();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox25.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox25.Refresh();
            thirdlvl.CountStarPlus();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox26.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox26.Refresh();
            thirdlvl.CountStarPlus();
            label1.Text = (32 - thirdlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Form_Menu form_menu = new Form_Menu();
            form_menu.Show();
            this.Hide();
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Third_lvl third_lvl = new Third_lvl();
            third_lvl.Show();
            this.Hide();
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Level_Menu level_menu = new Level_Menu();
            level_menu.Show();
            this.Hide();
        }

        private void Third_lvl_Load(object sender, EventArgs e)
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
