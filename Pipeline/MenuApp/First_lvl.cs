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
using System.IO;
using System.Diagnostics;
using System.Media;
using ClassLibrary;

namespace MenuApp
{
    public partial class First_lvl : Form
    {
        private SoundPlayer[] players;
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
            players = new SoundPlayer[3];
            players[0] = result_base.GetSuond(soundInfo == 1 ? 2 : 4);
            players[1] = result_base.GetSuond(soundInfo == 1 ? 3 : 4);
            players[2] = result_base.GetSuond(soundInfo == 1 ? 1 : 4);
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

            PlayAndWait(players[2], 300);
            stopwatch.Stop();
            PlayAndWait(players[1], 3000);

            int duration = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
            int[] result_arr = result_base.GetResultArray();
            int durationstart = result_arr.Length >= 2 ? result_arr[2] : 0;

            if (result_arr.Length >= 2 && firstlvl.GetCountStar() <= result_arr[1] && durationstart > duration)
            {
                result_base.ChangeInfoToBase(0, firstlvl.GetStars(), firstlvl.GetCountStar(), duration);
            }
            else
            {
                result_base.SetInfoToBase(firstlvl.GetStars(), firstlvl.GetCountStar(), duration);
            }

            PictureBox[] pictureBoxes = { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
            int[] finan = { 1, 9, 3, 8, 2, 0, 2, 0, 11 };

            players[0].Play();
            finanim.FinishAnim(pictureBoxes, finan);
            players[0].Stop();

            var form_result = new Form_result();
            form_result.SetStar(firstlvl.GetStars(), firstlvl.GetCountStar(), 2);
            form_result.Show();
            Hide();
        }

        private void PlayAndWait(SoundPlayer player, int milliseconds)
        {
            player.Play();
            Thread.Sleep(milliseconds);
        }

        private void First_lvl_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            Form_Menu form_menu = Application.OpenForms["Form_Menu"] as Form_Menu;
            form_menu?.GetSoundPlayer()?.Stop();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                int index = int.Parse(pictureBox.Tag.ToString());
                players[2].Play();
                
                if (index % 2 == 0)
                    firstlvl.Rotate90Deg(pictureBox, index / 2);
                else
                    firstlvl.Rotate180Deg(pictureBox, index / 2);

                if (index % 2 == 0)
                    firstlvl.CountDegrysZH1(index / 2);
                else
                    firstlvl.CountDegrysPR1(index / 2);

                label1.Text = (28 - firstlvl.GetCountStar()).ToString();
                if (firstlvl.GetFinishmark())
                    FinishAnimation();
                if (int.Parse(label1.Text) < 1)
                    LoseAnimation();
            }
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
