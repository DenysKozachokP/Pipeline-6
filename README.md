### Patterns

1. Singleton: This pattern is used to create a single instance of the game that will be accessible from anywhere in the program.
###### Create class OptionsClass:
```
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
    }
}
```
###### Example of using the class
```
SoundPlayer player;
OptionsClass optionsInstance = OptionsClass.GetInstance();
private void pictureBox1_Click_1(object sender, EventArgs e)
{
    DialogResult result = MessageBox.Show("Ви впевнені що хочете видалити прогрес?", "Підтверження", MessageBoxButtons.OKCancel);
    if (result == DialogResult.OK)
        optionsInstance.DeleteInfoToBase();
}
private void pictureBox2_Click(object sender, EventArgs e)
{
    optionsInstance.ChangeSoundOnOff(1);
    player.Play();
    this.Refresh();
}
private void pictureBox3_Click(object sender, EventArgs e)
{
    optionsInstance.ChangeSoundOnOff(0);
    player.Stop();
    this.Refresh();
}
```
2. Factory Method: This pattern is used to create objects of various block types in a queue.
###### Create class BlockFactory:
```
public class ImageFactory
{
    private string imgFolder = "D:\\Навчання_2_курс\\6-lab KPZ\\Pipeline\\img\\img for animation";

    private string[] imageFileNames = {
    "zognuta_truba_1.png", "zognuta_truba_2.png", "zognuta_truba_3.png", "zognuta_truba_4.png",
    "troina_truba_1.png", "troina_truba_2.png", "troina_truba_3.png", "troina_truba_4.png",
    "prama_truba_1.png", "prama_truba_2.png",
    "chetwerna_truba.png",
    "start-finish_truba.png"
};

    public Image GetImage(int index)
    {
        if (index >= 0 && index < imageFileNames.Length)
        {
            string imagePath = Path.Combine(imgFolder, imageFileNames[index]);
            return Image.FromFile(imagePath);
        }
        else
        {
            Console.WriteLine($"Invalid index for image: {index}");
            return null;
        }
    }
}
```
###### A class that uses a factory
```
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
```
3. The Observer pattern allows one object (subject) to notify other objects (observers) about changes in its state. By applying this pattern to your class, you can make other objects react to changes in the files or data of the Result_base class.
###### Observer interface
```
public interface IObserver
{
    void Update();
}
```
###### interface ISubject
```
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
```
###### The ResultBase class that implements the subject interface
```
public class Result_base : ISubject
{
    private static string _imgFolderPath = "D:\\Навчання_2_курс\\6-lab KPZ\\Pipeline\\img";
    private List<IObserver> _observers = new List<IObserver>();

    public static string GetFilePath(string fileName)
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
                    MessageBox.Show($"Unable to parse '{line}' to int.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        Notify();
    }

.......

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}
```
### Principles
