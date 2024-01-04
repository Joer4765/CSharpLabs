using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task_4;

public partial class MainWindow : Window
{
    private int[,] arr = new int[5, 5];
    private TextBox[,] entries = new TextBox[5, 5];

    public MainWindow()
    {
        InitializeComponent();

        // Create input widgets
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                entries[i, j] = new TextBox { Width = 50 };
                Grid.SetRow(entries[i, j], i);
                Grid.SetColumn(entries[i, j], j);
                MainGrid.Children.Add(entries[i, j]);
            }
        }
    }

    // Function to write array to binary file
    private static void WriteToFile(string filename, int[,] arr)
    {
        using var writer = new BinaryWriter(File.Open(filename, FileMode.Create));
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                writer.Write(arr[i, j]);
            }
        }
    }

    // Function to read array from binary file
    private static int[,] ReadFromFile(string filename)
    {
        var arr = new int[5, 5];
        using var reader = new BinaryReader(File.Open(filename, FileMode.Open));
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = reader.ReadInt32();
            }
        }

        return arr;
    }

    // Function to handle "Save" button press
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                arr[i, j] = int.Parse(entries[i, j].Text);
            }
        }
        WriteToFile("array.bin", arr);
    }

    // Function to handle "Load" button press
    private void LoadButton_Click(object sender, RoutedEventArgs e)
    {
        arr = ReadFromFile("array.bin");
        var transposedArray = new int[5, 5];
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                transposedArray[j,i] = arr[i,j];
            }
        }
        WriteToFile("transposed_array.bin", transposedArray);
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                entries[i, j].Text = transposedArray[i,j].ToString();
            }
        }
    }
}