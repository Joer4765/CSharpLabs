using System;
using System.IO;
using System.Windows;

namespace Task_5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num1 = 0;
            double num2 = 0;
            double result = 0;
            string operation = "";

            try
            {
                // Read input data from file
                string[] lines = File.ReadAllLines("input.txt");
                if (lines.Length < 2)
                {
                    throw new Exception("Input file must contain at least two numbers");
                }
                num1 = Convert.ToDouble(lines[0]);
                num2 = Convert.ToDouble(lines[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Get selected operation
            if (rbAdd.IsChecked == true)
            {
                operation = "+";
                result = num1 + num2;
            }
            else if (rbSubtract.IsChecked == true)
            {
                operation = "-";
                result = num1 - num2;
            }
            else if (rbMultiply.IsChecked == true)
            {
                operation = "*";
                result = num1 * num2;
            }
            else if (rbDivide.IsChecked == true)
            {
                operation = "/";
                if (num2 == 0)
                {
                    MessageBox.Show("Cannot divide by zero");
                    return;
                }
                result = num1 / num2;
            }
            else
            {
                MessageBox.Show("Please select an operation");
                return;
            }

            // Display result
            tbResult.Text = $"{num1} {operation} {num2} = {result}";

            // Write result to output file
            File.WriteAllText("output.txt", $"{num1} {operation} {num2} Result = {result}");
        }
    }
}