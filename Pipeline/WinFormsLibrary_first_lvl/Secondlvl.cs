using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsLibrary_first_lvl;
using WinFormsLibrary_Levels;

namespace WinFormsLibrary_Levels
{
    public class Secondlvl : Firstlvl
    {
        
        private int[] Angles2 = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        private int[] SumPoint2 = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        private int[] Finish2 = new int[13] { 3, 1, 3, 1, 3, 3, 3, 1, 0, 0, 1, 0, 1};
        public Secondlvl() : base()
        {

        }
        public Secondlvl(int[] angles, int[] sumpoint, int[] finish, bool finishmark, int tempznach, int countstar, int stars) : base(angles,sumpoint, finish, finishmark, tempznach, countstar, stars)
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
        public int GetSumPoints(int n)
        {
            return SumPoint2[n];
        }        
        public int GetFinish(int n)
        {
            return Finish2[n];
        }
        public int GetAngles(int n)
        {
            return Angles2[n];
        }
        //*******************
        public void CountDegrysZH2(int n)
        {
            CountStars++;
            if (Angles2[n] < 270)
            {
                Angles2[n] += 90;
                SumPoint2[n]++;
            }
            else
            {
                Angles2[n] = 0;
                SumPoint2[n] = 0;
            }
            for (int i = 0; i < 13; i++)
            {
                if (GetSumPoints(i) == GetFinish(i))
                    tempznach++;
            }
            if (tempznach == 13)
            {
                Finishmark = true;
                if (CountStars <= 23)
                    Stars = 3;
                else if (CountStars <= 25)
                    Stars = 2;
                else
                    Stars = 1;
            }
            tempznach = 0;
        }
        public void CountDegrysPR2(int n)
        {
            CountStars++;
            if (Angles2[n] < 90)
            {
                Angles2[n] += 90;
                SumPoint2[n]++;
            }
            else
            {
                Angles2[n] = 0;
                SumPoint2[n] = 0;
            }
            for (int i = 0; i < 13; i++)
            {
                if (GetSumPoints(i) == GetFinish(i))
                    tempznach++;
            }
            if (tempznach == 13)
            {
                Finishmark = true;
                if (CountStars <= 23)
                    Stars = 3;
                else if (CountStars <= 25)
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
