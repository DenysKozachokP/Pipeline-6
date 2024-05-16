using System.Media;
using WinFormsLibrary_Levels;

namespace MenuApp
{
    public partial class Form_Menu : Form
    {
        Result_base result_base = new Result_base();
        private SoundPlayer player;
        public Form_Menu()
        {
            InitializeComponent();
            player = result_base.GetSuond(0);
            if (result_base.GetSoundInfo() == 1)
                player.Play();
            if (result_base.GetSoundInfo() == 0)
                player.Stop();
            this.Refresh();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Level_Menu form1 = new Level_Menu();
            form1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TournamentBracket tournamentBracket = new TournamentBracket();
            tournamentBracket.Show();
            this.Hide();
        }
        public SoundPlayer GetSoundPlayer()
        {
            return player;
        }
        private void Form_Menu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені що хочете вийти?", "Підтверження", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}