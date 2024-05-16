using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WinFormsLibrary_first_lvl;
using WinFormsLibrary_Levels;
using System.IO;
using System.Diagnostics;
using System.Media;

namespace MenuApp
{
    public partial class First_lvl : Form
    {
        private SoundPlayer player;
        private SoundPlayer player1;
        private SoundPlayer player2;
        private SoundPlayer player3;
        private Firstlvl firstlvl = new Firstlvl();
        private Result_base result_base = new Result_base();
        private FinishAnimation finanim = new FinishAnimation();
        private Stopwatch stopwatch = new Stopwatch();

        public First_lvl()
        {
            InitializeComponent();
            InitializeSoundPlayers();
        }

        private void InitializeSoundPlayers()
        {
            int soundInfo = result_base.GetSoundInfo();
            player1 = result_base.GetSuond(soundInfo == 1 ? 2 : 4);
            player2 = result_base.GetSuond(soundInfo == 1 ? 3 : 4);
            player3 = result_base.GetSuond(soundInfo == 1 ? 1 : 4);
        }

        private void LoseAnimation()
        {
            new LoseForm() { TopLevel = false, Parent = this }.Show();
            Hide();
        }

        private void FinishAnimation()
        {
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            label1.Refresh();

            player3.Play();
            Thread.Sleep(300);
            stopwatch.Stop();
            player2.Play();
            Thread.Sleep(3000);

            int duration = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
            int durationstart = 0;
            Form_result form_result = new Form_result();
            form_result.SetStar(firstlvl.GetStars(), firstlvl.GetCountStar(), 2);

            int[] result_arr = result_base.GetResultArray();
            if (result_arr.Length >= 2)
                durationstart = result_arr[2];
            if (result_arr.Length >= 2 && firstlvl.GetCountStar() <= result_arr[1] && durationstart > duration)
                result_base.ChangeInfoToBase(0, firstlvl.GetStars(), firstlvl.GetCountStar(), duration);
            else
                result_base.SetInfoToBase(firstlvl.GetStars(), firstlvl.GetCountStar(), duration);

            PictureBox[] pictureBoxes = { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
            int[] finan = { 1, 9, 3, 8, 2, 0, 2, 0, 11 };

            player1.Play();
            finanim.FinishAnim(pictureBoxes, finan);
            player1.Stop();

            form_result.Show();
            Hide();
        }

        private void First_lvl_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            Form_Menu form_menu = Application.OpenForms["Form_Menu"] as Form_Menu;
            if (form_menu != null && (player = form_menu.GetSoundPlayer()) != null)
                player.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox2, 0);
            firstlvl.CountDegrysZH1(0);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate180Deg(pictureBox3, 1);
            firstlvl.CountDegrysPR1(1);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox4, 2);
            firstlvl.CountDegrysZH1(2);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate180Deg(pictureBox5, 3);
            firstlvl.CountDegrysPR1(3);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox6, 4);
            firstlvl.CountDegrysZH1(4);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox7, 5);
            firstlvl.CountDegrysZH1(5);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox8, 6);
            firstlvl.CountDegrysZH1(6);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            player3.Play();
            firstlvl.Rotate90Deg(pictureBox9, 7);
            firstlvl.CountDegrysZH1(7);
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (firstlvl.GetFinishmark())
                FinishAnimation();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox11.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox11.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox12.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox12.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox13.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox13.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox14.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox14.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox15.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox15.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            player3.Play();
            pictureBox16.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox16.Refresh();
            firstlvl.CountStarPlus();
            label1.Text = (28 - firstlvl.GetCountStar()).ToString();
            if (int.Parse(label1.Text) < 1)
                LoseAnimation();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Form_Menu form1 = new Form_Menu();
            form1.Show();
            this.Hide();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            First_lvl form_First_Lvl = new First_lvl();
            form_First_Lvl.Show();
            this.Hide();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Level_Menu Level_menu = new Level_Menu();
            Level_menu.Show();
            this.Hide();
        }
    }
}
