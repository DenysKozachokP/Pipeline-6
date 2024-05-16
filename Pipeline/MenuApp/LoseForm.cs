using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApp
{
    public partial class LoseForm : Form
    {
        public LoseForm()
        {
            InitializeComponent();
        }

        private void LoseForm_Load(object sender, EventArgs e)
        {

        }
        public void SetStar(int a)
        {           
            label1.Text = a.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "1")
            {
                First_lvl first_Lvl = new First_lvl();
                first_Lvl.Show();
                this.Hide();
            }
            if (label1.Text == "2")
            {
                Second_lvl second_lvl = new Second_lvl();
                second_lvl.Show();
                this.Hide();
            }
            if (label1.Text == "3")
            {
                Third_lvl third_lvl = new Third_lvl();
                third_lvl.Show();
                this.Hide();
            }
            if (label1.Text == "4")
            {
                Fourth_lvl fourth_lvl = new Fourth_lvl();
                fourth_lvl.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Level_Menu level_Menu = new Level_Menu();
            level_Menu.Show();
            this.Hide();
        }
    }
}
