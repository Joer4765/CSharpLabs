using System.Windows;


namespace Task_3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowDetails_Click(object sender, RoutedEventArgs e)
    {
        var textbook = new Textbook("Nakami", "Malyopus", 54, 51641, "Did Pykhto", "ISBN-BN", "Shuonen", 10);
        DetailsTextBlock.Text = textbook.Show();
    }
}