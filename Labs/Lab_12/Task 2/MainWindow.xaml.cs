using System.Windows;

namespace Task_2;

public partial class MainWindow
{
    private readonly OperatingSystem _os = new();
    
    public MainWindow()
    {
        InitializeComponent();
        
    }

    private void CreateOSButton_Click(object sender, RoutedEventArgs e)
    {

        _os.Name = "Windows";
        _os.Version = 10;
    }
    
    private void InstallOSButton_Click(object sender, RoutedEventArgs e)
    {
        _os.Install();
    }
    
    private void RunOSButton_Click(object sender, RoutedEventArgs e)
    {
        _os.Run();
    }
    
    private void StopOSButton_Click(object sender, RoutedEventArgs e)
    {
        _os.Stop();
    }
    
    private void UpdateOSButton_Click(object sender, RoutedEventArgs e)
    {
        _os.Update();
    }
    
    private readonly MobileApp _app = new();

    private void CreateAppButton_Click(object sender, RoutedEventArgs e)
    {

        _app.Name = "MyApp";
        _app.Version = 1;
        _app.Company = "MyCompany";
    }
    
    private void RunAppButton_Click(object sender, RoutedEventArgs e)
    {
        _app.Run();
    }
    
    private void DevelopAppButton_Click(object sender, RoutedEventArgs e)
    {
        _app.Develop();
    }
    
    private void ReleaseAppButton_Click(object sender, RoutedEventArgs e)
    {
        _app.Release();
    }
    
    private void StopAppButton_Click(object sender, RoutedEventArgs e)
    {
        _app.Stop();
    }
    
    private void TestAppButton_Click(object sender, RoutedEventArgs e)
    {
        _app.Test();
    }
    
    
}

internal interface IProgram
{
    string Name { get; set; }
    int Version { get; set; }
    void Run();
    void Stop();
}

internal interface IDeveloper
{
    string Name { get; set; }
    string Company { get; set; }
    void Develop();
    void Test();
}

internal class OperatingSystem : IProgram
{
    public string Name { get; set; }
    public int Version { get; set; }

    public void Run()
    {
        MessageBox.Show("OS is running...");
    }

    public void Stop()
    {
        MessageBox.Show("OS is stopping...");
    }

    public void Install()
    {
        MessageBox.Show("OS is being installed...");
    }

    public void Update()
    {
        MessageBox.Show("OS is being updated...");
    }
}

internal class MobileApp : IProgram, IDeveloper
{
    public string Name { get; set; }
    public int Version { get; set; }
    public string Company { get; set; }

    public void Run()
    {
        MessageBox.Show("App is running...");
    }

    public void Stop()
    {
        MessageBox.Show("App is stopping...");
    }

    public void Develop()
    {
        MessageBox.Show("App is being developed...");
    }

    public void Test()
    {
        MessageBox.Show("App is being tested...");
    }

    public void Release()
    {
        MessageBox.Show("App is being released...");
    }
}
