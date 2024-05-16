using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsLibrary_first_lvl;
using WinFormsLibrary_Levels;
using static System.Windows.Forms.DataFormats;

namespace MenuApp
{

    public partial class Level_Menu : Form
    {
        private SoundPlayer player;
        First_lvl lvl;
        Result_base result_base = new Result_base();
        public Level_Menu()
        {
            InitializeComponent();
            player = result_base.GetSuond(0);
            if (result_base.GetSoundInfo() == 1)
                player.Play();
            if (result_base.GetSoundInfo() == 0)
                player.Stop();
            this.Refresh();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form_Menu form_Menu = new Form_Menu();
            form_Menu.Show();
            this.Hide();
        }
        private void Level_Menu_Load(object sender, EventArgs e)
        {
            int[] num = result_base.GetResultArray();

            result_base.SetStarInLevelMenu(pictureBox9, 0);
            if (num.Length >= 3)
                pictureBoxLock2.Visible = false;
            if (num.Length >= 6)
            {
                result_base.SetStarInLevelMenu(pictureBox10, 3);
                pictureBoxLock3.Visible = false;
            }
            if (num.Length >= 9)
            {
                result_base.SetStarInLevelMenu(pictureBox13, 6);
                pictureBoxLock4.Visible = false;
            }
            if (num.Length >= 12)
            {
                result_base.SetStarInLevelMenu(pictureBox14, 9);
                pictureBoxLock5.Visible = false;
            }
            if (num.Length >= 15)
            {
                result_base.SetStarInLevelMenu(pictureBox12, 12);
                pictureBoxLock6.Visible = false;
            }
            if (num.Length >= 18)
            {
                result_base.SetStarInLevelMenu(pictureBox15, 15);
                pictureBoxLock7.Visible = false;
            }
            if (num.Length >= 21)
            {
                result_base.SetStarInLevelMenu(pictureBox16, 18);
                pictureBoxLock8.Visible = false;
            }
            if (num.Length >= 24)
                result_base.SetStarInLevelMenu(pictureBox17, 21);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            First_lvl form_first = new First_lvl();
            form_first.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Second_lvl form_second = new Second_lvl();
            form_second.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Third_lvl form_third = new Third_lvl();
            form_third.Show();
            this.Hide();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fourth_lvl fourth_lvl = new Fourth_lvl();
            fourth_lvl.Show();
            this.Hide();
        }
        private void Level_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }
    }
}
