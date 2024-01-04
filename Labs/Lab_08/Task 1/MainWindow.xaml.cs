// MainWindow.xaml.cs

using System.Linq;
using System.Windows;

namespace Task_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = Matrix2Text(Func(Text2Matrix(InputText.Text)));
        }

        private static string[][] Func(string[][] inputArray)
        {
            foreach (var t in inputArray)
            {
                for (var j = 0; j < t.Length; j++)
                {
                    if (int.TryParse(t[j], out _))
                    {
                        t[j] = "!";
                    }
                }
            }

            return inputArray;
        }

        private static string Matrix2Text(string[][] arr)
        {
            return string.Join("\n", arr.Select(row => string.Join(" ", row)));
        }

        private static string[][] Text2Matrix(string text)
        {
            return text.Split('\n').Select(row => row.Split()).ToArray();
        }
    }
}