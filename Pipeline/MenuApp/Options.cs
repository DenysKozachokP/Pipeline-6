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
using ClassLibrary;

namespace MenuApp
{
    public partial class Options : Form
    {
        private SoundPlayer _player;
        private Result_base _resultBase = new Result_base();
        private OptionsClass _optionsInstance = OptionsClass.GetInstance();

        public Options()
        {
            InitializeComponent();
            _player = _resultBase.GetSuond(0);
        }

        private void pictureBoxDeleteProgress_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the progress?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Result_base resultBase = new Result_base();
                ConcreteObserver observer = new ConcreteObserver(resultBase);
                _optionsInstance.DeleteInfoToBase();
            }
        }

        private void pictureBoxSoundOn_Click(object sender, EventArgs e)
        {
            _optionsInstance.ChangeSoundOnOff(1);
            _player.Play();
            Refresh();
        }

        private void pictureBoxSoundOff_Click(object sender, EventArgs e)
        {
            _optionsInstance.ChangeSoundOnOff(0);
            _player.Stop();
            Refresh();
        }

        private void pictureBoxNavigate_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Form formToShow;
            switch (pictureBox.Name)
            {
                case "pictureBoxNavigateMenu":
                    formToShow = new Form_Menu();
                    break;
                default:
                    return;
            }
            formToShow.Show();
            Hide();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player.Stop();
        }
    }
}
