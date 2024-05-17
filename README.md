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
###### 1 .(DIP) Dependency Inversion Principle 
The FinishAnimation class uses the ImageFactory object to create images. This allows the FinishAnimation class to not depend directly on the rendering details, but to use the factory to obtain the required resources. Thus, FinishAnimation depends on the abstraction (ImageFactory) and not on specific implementation details.
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
###### 2. KISS 
These changes keep the code clean and easily maintainable, in line with the KISS principle.
```
private SoundPlayer[] players;
private Firstlvl firstlvl = new Firstlvl();
private Result_base result_base = new Result_base();
private FinishAnimation finanim = new FinishAnimation();
private Stopwatch stopwatch = new Stopwatch();

public First_lvl()
{
    InitializeComponent();
    InitializeSoundPlayers();
}

private void InitializeSoundPlayers()
{
    int soundInfo = result_base.GetSoundInfo();
    players = new SoundPlayer[3];
    players[0] = result_base.GetSuond(soundInfo == 1 ? 2 : 4);
    players[1] = result_base.GetSuond(soundInfo == 1 ? 3 : 4);
    players[2] = result_base.GetSuond(soundInfo == 1 ? 1 : 4);
}

private void LoseAnimation()
{
    new LoseForm() { TopLevel = false, Parent = this }.Show();
    Hide();
}

private void FinishAnimation()
{
    label1.Text = (28 - firstlvl.GetCountStar()).ToString();
    label1.Refresh();

    PlayAndWait(players[2], 300);
    stopwatch.Stop();
    PlayAndWait(players[1], 3000);

    int duration = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
    int[] result_arr = result_base.GetResultArray();
    int durationstart = result_arr.Length >= 2 ? result_arr[2] : 0;

    if (result_arr.Length >= 2 && firstlvl.GetCountStar() <= result_arr[1] && durationstart > duration)
    {
        result_base.ChangeInfoToBase(0, firstlvl.GetStars(), firstlvl.GetCountStar(), duration);
    }
    else
    {
        result_base.SetInfoToBase(firstlvl.GetStars(), firstlvl.GetCountStar(), duration);
    }

    PictureBox[] pictureBoxes = { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
    int[] finan = { 1, 9, 3, 8, 2, 0, 2, 0, 11 };

    players[0].Play();
    finanim.FinishAnim(pictureBoxes, finan);
    players[0].Stop();

    var form_result = new Form_result();
    form_result.SetStar(firstlvl.GetStars(), firstlvl.GetCountStar(), 2);
    form_result.Show();
    Hide();
}
```
###### 3. OCP
Methods for working with sounds and images: Similarly, methods for working with sounds and images are also closed to change. For example, the SetStarInLevelMenu method is used to set the image in the level menu, and it can be extended to support new functionality without changing the base class.
```
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
```
###### 4. SPR
There are two operations in the FinishAnimation class: getting the images from the image factory and updating the images in the PictureBox. These two operations can change independently of each other, so they are separated into separate classes
```
public class FinishAnimation
{
    private ImageFactory imageFactory = new ImageFactory();

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
            Image image = imageFactory.GetImage(animIndex);
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
```
