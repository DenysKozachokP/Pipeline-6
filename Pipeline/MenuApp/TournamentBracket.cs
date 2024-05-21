using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApp
{
    public partial class TournamentBracket : Form
    {
        private readonly ResultBase _resultBase = new ResultBase();

        public TournamentBracket()
        {
            InitializeComponent();
        }

        private void TournamentBracket_Load(object sender, EventArgs e)
        {
            InitializeLevel(pictureBox1Lock, pictureBox1Star, label1Click, label1Time, 0);
            InitializeLevel(pictureBox2Lock, pictureBox2Star, label2Click, label2Time, 3);
            InitializeLevel(pictureBox3Lock, pictureBox3Star, label3Click, label3Time, 6);
            InitializeLevel(pictureBox4Lock, pictureBox4Star, label4Click, label4Time, 9);
            InitializeLevel(pictureBox5Lock, pictureBox5Star, label5Click, label5Time, 12);
            InitializeLevel(pictureBox6Lock, pictureBox6Star, label6Click, label6Time, 15);
            InitializeLevel(pictureBox7Lock, pictureBox7Star, label7Click, label7Time, 18);
            InitializeLevel(null, pictureBox8Star, label8Click, label8Time, 21); // No lock for the last level
        }

        private void InitializeLevel(PictureBox lockPictureBox, PictureBox starPictureBox, Label clickLabel, Label timeLabel, int index)
        {
            int[] num = _resultBase.GetResultArray();
            if (num.Length >= index + 3)
            {
                if (lockPictureBox != null)
                    lockPictureBox.Visible = false;

                _resultBase.SetStarInLevelMenu(starPictureBox, index);
                clickLabel.Text = num[index + 1].ToString();

                int totalSeconds = num[index + 2];
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;

                timeLabel.Text = $"{minutes:D2}:{seconds:D2}";
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Form_Menu form_Menu = new Form_Menu();
            form_Menu.Show();
            Hide();
        }
    }
}
