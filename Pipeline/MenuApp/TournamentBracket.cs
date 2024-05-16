using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsLibrary_Levels;

namespace MenuApp
{
    public partial class TournamentBracket : Form
    {
        Result_base resultbase = new Result_base();

        public TournamentBracket()
        {
            InitializeComponent();
        }

        private void TournamentBracket_Load(object sender, EventArgs e)
        {
            
            int[] num = resultbase.GetResultArray();
            int tempmin;
            int tempsec;
            if (num.Length >=3)
            {
                pictureBox2Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox1Star, 0);
                label1Click.Text = num[1].ToString();
                tempmin = (int) num[2] / 60;
                tempsec = (int)  (num[2] - (tempmin * 60));
                label1Time.Text =( tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString() )+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=6)
            {
                pictureBox3Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox2Star, 3);
                label2Click.Text = num[4].ToString();
                tempmin = (int)num[5] / 60;
                tempsec = (int)(num[5] - (tempmin * 60));
                label2Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=9)
            {
                pictureBox4Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox3Star, 6);
                label3Click.Text = num[7].ToString();
                tempmin = (int)num[8] / 60;
                tempsec = (int)(num[8] - (tempmin * 60));
                label3Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=12)
            {
                pictureBox5Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox4Star, 9);
                label4Click.Text = num[10].ToString();
                tempmin = (int)num[11] / 60;
                tempsec = (int)(num[11] - (tempmin * 60));
                label4Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=15)
            {
                pictureBox6Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox5Star, 12);
                label5Click.Text = num[13].ToString();
                tempmin = (int)num[14] / 60;
                tempsec = (int)(num[14] - (tempmin * 60));
                label5Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=18)
            {
                pictureBox7Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox6Star, 15);
                label6Click.Text = num[16].ToString();
                tempmin = (int)num[17] / 60;
                tempsec = (int)(num[17] - (tempmin * 60));
                label6Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=21)
            {
                pictureBox8Lock.Visible = false;
                resultbase.SetStarInLevelMenu(pictureBox7Star, 18);
                label7Click.Text = num[19].ToString();
                tempmin = (int)num[20] / 60;
                tempsec = (int)(num[20] - (tempmin * 60));
                label7Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
            if (num.Length >=24)
            {
                resultbase.SetStarInLevelMenu(pictureBox8Star, 21);
                label8Click.Text = num[22].ToString();
                tempmin = (int)num[23] / 60;
                tempsec = (int)(num[23] - (tempmin * 60));
                label8Time.Text =(tempmin >= 10 ? tempmin.ToString() : "0" + tempmin.ToString())+ ":" + (tempsec >= 10 ? tempsec.ToString() : "0" + tempsec.ToString());
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Form_Menu form_Menu = new Form_Menu();
            form_Menu.Show();
            this.Hide();
        }
    }
}
