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
        private readonly ImageFactory _imageFactory;

        public FinishAnimation(ImageFactory imageFactory)
        {
            _imageFactory = imageFactory;
        }

        public void FinishAnim(PictureBox[] pictureBoxes, int[] finanim)
        {
            Image[] images = GetImages(finanim);
            UpdatePictureBoxes(pictureBoxes, images);
        }

        private Image[] GetImages(int[] finanim)
        {
            List<Image> images = new List<Image>();
            foreach (int animIndex in finanim)
            {
                Image image = _imageFactory.GetImage(animIndex);
                if (image != null)
                    images.Add(image);
            }
            return images.ToArray();
        }

        private void UpdatePictureBoxes(PictureBox[] pictureBoxes, Image[] images)
        {
            for (int i = 0; i < Math.Min(pictureBoxes.Length, images.Length); i++)
            {
                pictureBoxes[i].Image?.Dispose();
                pictureBoxes[i].Image = images[i];
                pictureBoxes[i].Refresh();
            }
        }
    }
}
