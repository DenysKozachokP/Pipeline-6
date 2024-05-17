using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{

    public class FinishAnimation
    {
        private ImageFactory imageFactory = new ImageFactory();

        public void FinishAnim(PictureBox[] pictureBoxes, int[] finanim)
        {
            for (int i = 0; i < finanim.Length; i++)
            {
                Image image = imageFactory.GetImage(finanim[i]);
                if (image != null)
                {
                    pictureBoxes[i].Image?.Dispose();
                    pictureBoxes[i].Image = image;
                    pictureBoxes[i].Refresh();
                }
            }
        }
    }
}
