using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MenuApp
{
    public partial class Second_lvl : Form
    {
        private SoundPlayer[] players;
        private Secondlvl second_lvl = new Secondlvl();
        private Result_base result_base = new Result_base();
        private FinishAnimation animation = new FinishAnimation();
        private Stopwatch stopwatch = new Stopwatch();

        public Second_lvl()
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
            loseForm.SetStar(2);
            loseForm.Show();
            this.Hide();
        }

        private void FinishAnimation()
        {
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            label1.Refresh();
            players[2].Play();
            Thread.Sleep(300);
            stopwatch.Stop();
            players[1].Play();
            Thread.Sleep(3000);

            int duration = (int)stopwatch.Elapsed.TotalSeconds;
            Form_result form_result = new Form_result();
            form_result.SetStar(second_lvl.GetStars(), second_lvl.GetCountStar(), 3);

            UpdateResultBase(duration);

            PictureBox[] pictureBoxes = {
            pictureBox3, pictureBox6, pictureBox4, pictureBox2, pictureBox7, pictureBox5,
            pictureBox17, pictureBox10, pictureBox8, pictureBox9, pictureBox12, pictureBox11,
            pictureBox13, pictureBox14
        };
            int[] fina = { 6, 0, 9, 3, 8, 8, 1, 2, 3, 0, 1, 7, 8, 11 };

            players[0].Play();
            animation.FinishAnim(pictureBoxes, fina);
            players[0].Stop();

            form_result.Show();
            this.Hide();
        }

        private void UpdateResultBase(int duration)
        {
            int[] result_arr = result_base.GetResultArray();
            int currentStars = second_lvl.GetStars();
            int currentCountStar = second_lvl.GetCountStar();

            if (result_arr.Length >= 6)
            {
                int previousCountStar = result_arr[4];
                int previousDuration = result_arr[5];

                if (currentCountStar < previousCountStar || (currentCountStar == previousCountStar && previousDuration > duration))
                {
                    result_base.ChangeInfoToBase(3, currentStars, currentCountStar, duration);
                }
            }
            else if (result_arr.Length == 3)
            {
                result_base.SetInfoToBase(currentStars, currentCountStar, duration);
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox3, 0);
            second_lvl.CountDegrysZH2(0);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox4, 1);
            second_lvl.CountDegrysPR2(1);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox2, 2);
            second_lvl.CountDegrysZH2(2);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox5, 3);
            second_lvl.CountDegrysPR2(3);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox10, 4);
            second_lvl.CountDegrysZH2(4);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox9, 5);
            second_lvl.CountDegrysZH2(5);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox11, 6);
            second_lvl.CountDegrysZH2(6);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox13, 7);
            second_lvl.CountDegrysPR2(7);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox12, 8);
            second_lvl.CountDegrysZH2(8);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox8, 9);
            second_lvl.CountDegrysZH2(9);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox17, 10);
            second_lvl.CountDegrysZH2(10);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox7, 11);
            second_lvl.CountDegrysPR2(11);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            players[2].Play();
            second_lvl.Rotate90Deg(pictureBox6, 12);
            second_lvl.CountDegrysZH2(12);
            if (second_lvl.GetFinishmark())
                FinishAnimation();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox16.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox16.Refresh();
            second_lvl.CountStarPlus();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox15.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox15.Refresh();
            second_lvl.CountStarPlus();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            players[2].Play();
            pictureBox23.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox23.Refresh();
            second_lvl.CountStarPlus();
            label1.Text = (32 - second_lvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void Second_lvl_Load(object sender, EventArgs e)
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
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Form_Menu form_menu = new Form_Menu();
            form_menu.Show();
            this.Hide();
        }
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Second_lvl second_lvl = new Second_lvl();
            second_lvl.Show();
            this.Hide();
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Level_Menu level_menu = new Level_Menu();
            level_menu.Show();
            this.Hide();
        }
    }
}
