using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Task_1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void FuncButton_Click(object sender, RoutedEventArgs e)
    {
        var filename = InputText.Text;
        OutputText.Text = Arr2Text(Func(filename));
    }

    private static IEnumerable<string[]> Func(string filename)
    {
        // define number of parameters
        const int numParams = 10;

        // read data from file into array
        var data = new List<string[]>();
        using (var sr = new StreamReader(filename))
        {
            while (sr.ReadLine() is { } line)
            {
                var param = line.Trim().Split(';');
                if (param.Length == numParams)
                {
                    data.Add(param);
                }
            }
        }

        // process data

        return data.Where(security => 2023 - int.Parse(security[^1]) > 10).ToList();
    }

    private static string Arr2Text(IEnumerable<string[]> arr)
    {
        // convert array to text
        return arr.Aggregate("", (current, row) => current + string.Join(";", row) + "\n");
    }
}