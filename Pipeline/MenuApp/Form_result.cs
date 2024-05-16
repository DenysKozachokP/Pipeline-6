using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApp
{
    public partial class Form_result : Form
    {
        public Form_result()
        {
            InitializeComponent();
        }
        public void SetStar(int star, int click, int a)
        {
            string imgFolder = "D:\\Навчання_2_курс\\Констроювання програмного\\KPZ\\lab-6\\Pipeline\\img";
            string imageFileName3 = "gold_stars_3.png";
            string imageFileName2 = "gold_stars_2.png";
            string imageFileName1 = "gold_stars_1.png";

            string imagePath3 = Path.Combine(imgFolder, imageFileName3);
            string imagePath2 = Path.Combine(imgFolder, imageFileName2);
            string imagePath1 = Path.Combine(imgFolder, imageFileName1);

            Image image3 = Image.FromFile(imagePath3);
            Image image2 = Image.FromFile(imagePath2);
            Image image1 = Image.FromFile(imagePath1);

            if (star == 3)
                pictureBox1.Image = image3;
            else if (star == 2)
                pictureBox1.Image = image2;
            else
                pictureBox1.Image = image1;

            label2.Text = click.ToString();
            label3.Text = a.ToString();
        }
        private void First_lvl_fin_Load(object sender, EventArgs e)
        {
            if (label3.Text == "9")
            {
                pictureBox4.Visible = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Level_Menu level_menu = new Level_Menu();
            level_menu.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form_Menu form_menu = new Form_Menu();
            form_menu.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (label3.Text == "2")
            {
                Second_lvl second_lvl = new Second_lvl();
                second_lvl.Show();
                this.Hide();
            }
            if (label3.Text == "3")
            {
                Third_lvl third_lvl = new Third_lvl();  
                third_lvl.Show();
                this.Hide();
            }
            if (label3.Text == "4")
            {
                Fourth_lvl fourth_lvl = new Fourth_lvl();
                fourth_lvl.Show();
                this.Hide();
            }            
        }
    }
}
