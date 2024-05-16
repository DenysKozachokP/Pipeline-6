### Patterns
1. Factory Method: This pattern is used to create objects of various block types in a queue.
#### Create class BlockFactory:

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
