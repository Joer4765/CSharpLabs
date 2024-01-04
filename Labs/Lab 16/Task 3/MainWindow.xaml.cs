using System.Windows;

namespace Task_3;

public partial class MainWindow
{
    private readonly BinaryTree _tree = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Insert_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(Number.Text, out var key))
        {
            _tree.Insert(key, Title.Text);
            UpdateTreeDisplay();
            UpdateResultLabel("Insertion successful.");
        }
        else
        {
            MessageBox.Show("Please enter a valid integer.", "Error");
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(Number.Text, out var key))
        {
            _tree.Delete(key);
            Number.Clear();
            UpdateTreeDisplay();
            UpdateResultLabel("Deletion successful.");
        }
        else
        {
            MessageBox.Show("Please enter a valid integer.", "Error");
        }
    }

    private void Search_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(Number.Text, out var key))
        {
            
            if (_tree.Search(key) != null)
            {
                var result = _tree.Search(key).Str;
                Number.Clear();
                UpdateResultLabel("Search result: " + result);
            }
            else
            {
                UpdateResultLabel("Node not found");
            }
        }
        else
        {
            MessageBox.Show("Please enter a valid integer.", "Error");
        }
    }

    private void UpdateResultLabel(string text)
    {
        ResultLabel.Content = text;
    }

    private void UpdateTreeDisplay()
    {
        var result = _tree.InorderTraversal();
        TreeDisplay.Content = "Binary Search Tree: " + string.Join(" ", result);
    }
}