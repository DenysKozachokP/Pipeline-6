using ClassLibrary;
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
using static System.Windows.Forms.DataFormats;

namespace MenuApp
{

    public partial class Level_Menu : Form
    {
        private SoundPlayer player;
        private Result_base result_base = new Result_base();

        public Level_Menu()
        {
            InitializeComponent();
            InitializeSound();
            InitializeLevelMenu();
        }

        private void InitializeSound()
        {
            player = result_base.GetSuond(0);
            if (result_base.GetSoundInfo() == 1)
                player.Play();
            else
                player.Stop();
            Refresh();
        }

        private void InitializeLevelMenu()
        {
            int[] num = result_base.GetResultArray();

            result_base.SetStarInLevelMenu(pictureBox9, 0);
            UpdateLockVisibility(num.Length);
        }

        private void UpdateLockVisibility(int numLength)
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>()
            {
                pictureBoxLock2, pictureBoxLock3, pictureBoxLock4,
                pictureBoxLock5, pictureBoxLock6, pictureBoxLock7,
                pictureBoxLock8
            };

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Visible = numLength >= (i + 1) * 3;
            }
        }

        private void GoToLevel<T>() where T : Form, new()
        {
            T form = new T();
            form.Show();
            Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            GoToLevel<Form_Menu>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GoToLevel<First_lvl>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GoToLevel<Second_lvl>();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GoToLevel<Third_lvl>();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            GoToLevel<Fourth_lvl>();
        }

        private void Level_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }
    }
}
