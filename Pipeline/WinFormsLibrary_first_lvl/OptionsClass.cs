using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary_Levels
{
    public class OptionsClass : Result_base
    {
        private static OptionsClass instance;

        private OptionsClass() { }

        public static OptionsClass GetInstance()
        {
            if (instance == null)
            {
                instance = new OptionsClass();
            }
            return instance;
        }

        public void DeleteInfoToBase()
        {
            string filePath = GetFilePath("base_star.txt");
            File.WriteAllLines(filePath, new string[] { string.Empty });
        }
        public void ChangeSoundOnOff(int n)
        {
            string filePath = GetFilePath("Sound_on_off.txt");
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
