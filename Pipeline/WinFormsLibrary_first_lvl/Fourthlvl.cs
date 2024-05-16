using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary_Levels
{
    public class Fourthlvl : Secondlvl
    {
        private int[] Angles4 = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] SumPoint4 = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] Finish4 = new int[13] { 1, 0, 0, 3, 0, 1, 0, 0, 3, 0, 3, 3, 3 };

        public Fourthlvl() : base()
        {

        }
        public Fourthlvl(int[] angles, int[] sumpoint, int[] finish, bool finishmark, int tempznach, int countstar, int stars) : base(angles, sumpoint, finish, finishmark, tempznach, countstar, stars)
        {

        }
        public override int GetCountStar()
        {
            return base.CountStars;
        }
        public override int GetStars()
        {
            return base.Stars;
        }
        public override bool GetFinishmark()
        {
            return base.Finishmark;
        }
        //*******************
        public int GetAngles4(int n)
        {
            return Angles4[n];
        }
        public int GetSumPoints4(int n)
        {
            return SumPoint4[n];
        }
        public int GetFinish4(int n)
        {
            return Finish4[n];
        }
        //*******************
        public void CountDegrysZH4(int n)
        {
            CountStars++;
            if (Angles4[n] < 270)
            {
                Angles4[n] += 90;
                SumPoint4[n]++;
            }
            else
            {
                Angles4[n] = 0;
                SumPoint4[n] = 0;
            }
            for (int i = 0; i < 13; i++)
            {
                if (GetSumPoints4(i) == GetFinish4(i))
                    tempznach++;
            }
            if (tempznach == 13)
            {
                Finishmark = true;
                if (CountStars <= 20)
                    Stars = 3;
                else if (CountStars <= 23)
                    Stars = 2;
                else
                    Stars = 1;
            }
            tempznach = 0;
        }
        public void CountDegrysPR4(int n)
        {
            CountStars++;
            if (Angles4[n] < 90)
            {
                Angles4[n] += 90;
                SumPoint4[n]++;
            }
            else
            {
                Angles4[n] = 0;
                SumPoint4[n] = 0;
            }
            for (int i = 0; i < 13; i++)
            {
                if (GetSumPoints4(i) == GetFinish4(i))
                    tempznach++;
            }
            if (tempznach == 13)
            {
                Finishmark = true;
                if (CountStars <= 20)
                    Stars = 3;
                else if (CountStars <= 23)
                    Stars = 2;
                else
                    Stars = 1;
            }
            else
                tempznach = 0;
        }
        public override void CountStarPlus()
        {
            base.CountStarPlus();
        }
        public override PictureBox Rotate180Deg(PictureBox pictureBox, int n)
        {
            return base.Rotate180Deg(pictureBox, n);
        }
        public override PictureBox Rotate90Deg(PictureBox pictureBox, int n)
        {
            return base.Rotate90Deg(pictureBox, n);
        }
    }
}
