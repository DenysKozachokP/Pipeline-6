using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary_Levels
{
    public class Thirdlvl : Secondlvl
    {
        private int[] Angles3 = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        private int[] SumPoint3 = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        private int[] Finish3 = new int[15] { 1, 0, 3, 2, 3, 1, 0, 1, 0, 1, 3, 1, 0, 3, 0 };

        public Thirdlvl() : base()
        {

        }
        public Thirdlvl(int[] angles, int[] sumpoint, int[] finish, bool finishmark, int tempznach, int countstar, int stars) : base(angles, sumpoint, finish, finishmark, tempznach, countstar, stars)
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
        //****************
        public int GetAngles3(int n)
        {
            return Angles3[n];
        }
        public int GetSumPoints3(int n)
        {
            return SumPoint3[n];
        }
        public int GetFinish3(int n)
        {
            return Finish3[n];
        }
        //****************
        public void CountDegrysZH3(int n)
        {
            CountStars++;
            if (Angles3[n] < 270)
            {
                Angles3[n] += 90;
                SumPoint3[n]++;
            }
            else
            {
                Angles3[n] = 0;
                SumPoint3[n] = 0;
            }
            for (int i = 0; i < 15; i++)
            {
                if (GetSumPoints3(i) == GetFinish3(i))
                    tempznach++;
            }
            if (tempznach == 15)
            {
                Finishmark = true;
                if (CountStars <= 22)
                    Stars = 3;
                else if (CountStars <= 24)
                    Stars = 2;
                else
                    Stars = 1;
            }
            tempznach = 0;
        }
        public void CountDegrysPR3(int n)
        {
            CountStars++;
            if (Angles3[n] < 90)
            {
                Angles3[n] += 90;
                SumPoint3[n]++;
            }
            else
            {
                Angles3[n] = 0;
                SumPoint3[n] = 0;
            }
            for (int i = 0; i < 15; i++)
            {
                if (GetSumPoints3(i) == GetFinish3(i))
                    tempznach++;
            }
            if (tempznach == 15)
            {
                Finishmark = true;
                if (CountStars <= 22)
                    Stars = 3;
                else if (CountStars <= 24)
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
