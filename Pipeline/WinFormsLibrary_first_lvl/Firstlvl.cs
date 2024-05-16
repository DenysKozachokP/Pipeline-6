using System.Reflection.Emit;
using System.Windows.Forms;
using WinFormsLibrary_first_lvl;

namespace WinFormsLibrary_first_lvl
{
    public class Firstlvl
    {
        private int[] Angles = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] SumPoint = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] Finish = new int[8] { 3, 1, 3, 0, 0, 0, 2, 0};
        public bool Finishmark { set; get;}
        public int tempznach { set; get;}
        public int CountStars { set; get;}
        public int Stars { set; get;}

        public Firstlvl()
        {
            Finishmark = false;
            tempznach = 0;
            CountStars = 0;
            Stars = 0;
        }
        public Firstlvl(int[] angles, int[] sumpoint, int[] finish, bool finishmark, int tempznach, int countstar, int stars)
        {
            Angles = angles;
            SumPoint = sumpoint;
            Finish = finish;
            Finishmark = finishmark;
            CountStars = countstar;
            Stars = stars;
        }
        public virtual int GetCountStar()
        {
            return CountStars;
        }
        public virtual int GetStars()
        {
            return Stars;
        }
        public virtual bool GetFinishmark()
        {
            return Finishmark;
        }
        public void CountDegrysZH1(int n)
        {
            CountStars++;
            if (Angles[n] < 270)
            {
                Angles[n] += 90;
                SumPoint[n]++;
            }
            else
            {
                Angles[n] = 0;
                SumPoint[n] = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (SumPoint[i] == Finish[i])
                    tempznach++;
            }
            if (tempznach == 8)
            {
                if (CountStars <= 12 )
                    Stars = 3;
                else if (CountStars <= 15)
                    Stars = 2;
                else
                    Stars = 1;
                Finishmark = true;
            }
            tempznach = 0;
        }
        public void CountDegrysPR1(int n)
        {
            CountStars++;
            if (Angles[n] < 90)
            {
                Angles[n] += 90;
                SumPoint[n]++;
            }  
            else
            {
                Angles[n] = 0;
                SumPoint[n] = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (SumPoint[i] == Finish[i])
                    tempznach++;
            }
            if (tempznach == 8)
            {
                if (CountStars <=10)
                    Stars = 3;
                else if (CountStars <= 20)
                    Stars = 2;
                else
                    Stars = 1;
                Finishmark = true;
            }
            else
                tempznach = 0;
        }
        public virtual void CountStarPlus()
        {
            CountStars++;
        }
        public virtual PictureBox Rotate90Deg(PictureBox pictureBox , int n)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Refresh();
            return pictureBox;
        }
        public virtual PictureBox Rotate180Deg(PictureBox pictureBox, int n)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Refresh();
            return pictureBox;
        }
    }
}
