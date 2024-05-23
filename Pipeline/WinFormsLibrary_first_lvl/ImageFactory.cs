using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ImageFactory
    {
        private readonly string _imgFolder;
        private readonly string[] _imageFileNames;

        public ImageFactory(string imgFolder, string[] imageFileNames)
        {
            _imgFolder = imgFolder;
            _imageFileNames = imageFileNames;
        }

        public Image GetImage(int index)
        {
            if (index >= 0 && index < _imageFileNames.Length)
            {
                string imagePath = Path.Combine(_imgFolder, _imageFileNames[index]);
                return Image.FromFile(imagePath);
            }
            else
            {
                Console.WriteLine($"Invalid index for image: {index}");
                return null;
            }
        }
    }
}
