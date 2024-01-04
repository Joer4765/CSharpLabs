using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_2
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateRandomArray_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(nTextBox.Text);
            List<int> array = new List<int>(n);
            Random rand = new Random();

            resultTextBox.Text = "Input massive:\n";

            for (int i = 0; i < n; i++)
            {
                int value = rand.Next(-9, 10);
                array.Add(value);
                resultTextBox.Text += value + " ";
            }

            resultTextBox.Text += "\n";

            var avg = array.Average();
            resultTextBox.Text += "Average = " + avg + "\n";

            resultTextBox.Text += "El - avg:\n";
            var elMinusAvg = array.Select(x => x - avg);
            resultTextBox.Text += string.Join(" ", elMinusAvg) + "\n\n";

            resultTextBox.Text += "Count of greater than avg:\n";
            var countGreaterThanAvg = array.Where(x => x > avg).Count();
            resultTextBox.Text += countGreaterThanAvg + "\n\n";


            resultTextBox.Text += "Is arr sum double digit:\n";
            var isDoubleDigitSum = 10 <= array.Aggregate((a, b) => a + b) && array.Aggregate((a, b) => a + b) <= 100;
            resultTextBox.Text += (isDoubleDigitSum ? "Arr sum is double digit" : "Arr sum is not double digit") + "\n\n";

            resultTextBox.Text += "Count not in interval:\n";
            var countNotInInterval = array.Take(array.Count - (int.Parse(bTextBox.Text) - int.Parse(aTextBox.Text)));
            resultTextBox.Text += countNotInInterval.Count() + "\n\n";
        }
    }
}