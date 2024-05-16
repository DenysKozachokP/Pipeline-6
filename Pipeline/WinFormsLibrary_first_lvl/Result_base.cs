using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinFormsLibrary_first_lvl;

namespace WinFormsLibrary_Levels
{
    public class Result_base
    {
        private static string _imgFolderPath = "D:\\Навчання_2_курс\\Констроювання програмного\\KPZ\\lab-6\\Pipeline\\img";
        private static string GetFilePath(string fileName)
        {
            return Path.Combine(_imgFolderPath, fileName);
        }
        public int[] GetResultArray()
        {
            string filePath = GetFilePath("base_star.txt");

            List<int> numbers = new List<int>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return numbers.ToArray();
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        break;

                    if (int.TryParse(line, out int number))
                        numbers.Add(number);
                    else
                        Console.WriteLine($"Unable to parse '{line}' to int.");
                }
            }

            return numbers.ToArray();
        }
        public void SetInfoToBase(int star, int clicks, int time)
        {
            string filePath = GetFilePath("base_star.txt");
            string[] lines = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];

            if (lines.Length == 0)
            {
                lines = new string[] { star.ToString(), clicks.ToString(), time.ToString() };
            }
            else
            {
                File.AppendAllText(filePath, star + Environment.NewLine);
                File.AppendAllText(filePath, clicks + Environment.NewLine);
                File.AppendAllText(filePath, time + Environment.NewLine);
            }
        }
        public void ChangeInfoToBase(int n, int star, int click, int time)
        {
            string filePath = GetFilePath("base_star.txt");
            string[] lines = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];

            if (lines.Length >= n + 3)
            {
                lines[n] = star.ToString();
                lines[n + 1] = click.ToString();
                lines[n + 2] = time.ToString();
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                Console.WriteLine("Invalid index for changing information.");
            }
        }

        public void DeleteInfoToBase()
        {
            string filePath = GetFilePath("base_star.txt");
            File.WriteAllLines(filePath, new string[] { string.Empty });
        }
        public PictureBox SetStarInLevelMenu(PictureBox pictureBox, int n)
        {
            string[] imagePaths = {
            "gold_stars_0.png",
            "gold_stars_1.png",
            "gold_stars_2.png",
            "gold_stars_3.png"
            };

            Image[] images = new Image[imagePaths.Length];

            for (int i = 0; i < imagePaths.Length; i++)
            {
                images[i] = Image.FromFile(GetFilePath(imagePaths[i]));
            }

            int[] num = GetResultArray();
            if (num.Length > 1 && n < num.Length)
            {
                pictureBox.Image = images[Math.Min(num[n], images.Length - 1)];
            }
            else
            {
                pictureBox.Image = images[0];
            }
            return pictureBox;
        }
        public SoundPlayer GetSuond(int n)
        {
            string[] soundPaths = {
            "fone_sound.wav",
            "click.wav",
            "anim_watr.wav",
            "victory.wav",
            "empty.wav"
        };

            SoundPlayer[] players = new SoundPlayer[soundPaths.Length];

            for (int i = 0; i < soundPaths.Length; i++)
            {
                players[i] = new SoundPlayer(GetFilePath(soundPaths[i]));
            }

            return players[Math.Min(n, players.Length - 1)];
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
        public int GetSoundInfo()
        {
            string filePath = GetFilePath("Sound_on_off.txt");
            string[] lines = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[0];

            if (lines.Length > 0 && int.TryParse(lines[0], out int n))
                return n;
            else
                return 0;
        }
    }
}
