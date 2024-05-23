using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OptionsClass : Result_base
    {
        private static OptionsClass _instance;

        private OptionsClass(string imgFolderPath) : base(imgFolderPath) { }

        public static OptionsClass GetInstance(string imgFolderPath)
        {
            if (_instance == null)
            {
                _instance = new OptionsClass(imgFolderPath);
            }
            return _instance;
        }

        public void DeleteInfoFromBase()
        {
            string filePath = GetFilePath(_imgFolderPath, "base_star.txt");
            File.WriteAllText(filePath, string.Empty);
        }

        public void ChangeSoundOnOff(int n)
        {
            string filePath = GetFilePath(_imgFolderPath, "Sound_on_off.txt");
            string[] lines = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];

            if (lines.Length > 0)
            {
                lines[0] = n.ToString();
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                Console.WriteLine("Sound on/off file not found.");
            }
        }
    }
}
