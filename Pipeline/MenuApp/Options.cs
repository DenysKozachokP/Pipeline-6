using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsLibrary_Levels;
using WinFormsLibrary_first_lvl;

namespace MenuApp
{
    public partial class Options : Form
    {
        SoundPlayer player;
        Result_base result_Base = new Result_base();
        public Options()
        {
            InitializeComponent();
            player = result_Base.GetSuond(0);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form_Menu form_Menu = new Form_Menu();
            form_Menu.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені що хочете видалити прогрес?", "Підтверження", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                result_Base.DeleteInfoToBase();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            result_Base.ChangeSoundOnOff(1);
            player.Play();
            this.Refresh();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            result_Base.ChangeSoundOnOff(0);
            player.Stop();
            this.Refresh();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }
    }
}
