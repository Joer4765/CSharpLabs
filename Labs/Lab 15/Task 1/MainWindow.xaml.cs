using System.Windows;

namespace Task_1;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void OpenSinglyLinkedList(object sender, RoutedEventArgs e)
    {
        var sllGui = new SllGUI();
        sllGui.Show();
    }

    private void OpenDoublyLinkedList(object sender, RoutedEventArgs e)
    {
        var dllGui = new DllGUI();
        dllGui.Show();
    }
}