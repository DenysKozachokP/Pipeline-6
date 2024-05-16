using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLibrary_Levels
{
    public class FinishAnimation
    {

        public void FinishAnim(PictureBox[] pictureBoxes, int[] finanim)
        {
            string imgFolder = "D:\\Навчання_2_курс\\Констроювання програмного\\KPZ\\lab-6\\Pipeline\\img\\img for animation";

            string[] imageFileNames = {
                "zognuta_truba_1.png", "zognuta_truba_2.png", "zognuta_truba_3.png", "zognuta_truba_4.png",
                "troina_truba_1.png", "troina_truba_2.png", "troina_truba_3.png", "troina_truba_4.png",
                "prama_truba_1.png", "prama_truba_2.png",
                "chetwerna_truba.png",
                "start-finish_truba.png"
            };

            Image[] images = new Image[imageFileNames.Length];

            for (int i = 0; i < imageFileNames.Length; i++)
            {
                string imagePath = Path.Combine(imgFolder, imageFileNames[i]);
                images[i] = Image.FromFile(imagePath);
            }

            for (int i = 0; i < finanim.Length; i++)
            {
                if (finanim[i] >= 0 && finanim[i] < images.Length)
                {
                    pictureBoxes[i].Image?.Dispose();
                    pictureBoxes[i].Image = images[finanim[i]];
                    pictureBoxes[i].Refresh();
                }
                else
                {
                    Console.WriteLine($"Invalid index for animation: {finanim[i]}");
                }
            }
        }
    }
}
