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
using ClassLibrary;

namespace MenuApp
{
    public partial class LoseForm : Form
    {
        public LoseForm()
        {
            InitializeComponent();
        }

        public void SetStar(int starNumber)
        {
            label1.Text = starNumber.ToString();
        }

        private void pictureBoxRestart_Click(object sender, EventArgs e)
        {
            int starNumber = int.Parse(label1.Text);

            Form formToOpen;
            switch (starNumber)
            {
                case 1:
                    formToOpen = new First_lvl();
                    break;
                case 2:
                    formToOpen = new Second_lvl();
                    break;
                case 3:
                    formToOpen = new Third_lvl();
                    break;
                case 4:
                    formToOpen = new Fourth_lvl();
                    break;
                default:
                    // Handle other cases if needed
                    return;
            }

            formToOpen.Show();
            Hide();
        }

        private void pictureBoxMainMenu_Click(object sender, EventArgs e)
        {
            Level_Menu levelMenu = new Level_Menu();
            levelMenu.Show();
            Hide();
        }
    }
}
