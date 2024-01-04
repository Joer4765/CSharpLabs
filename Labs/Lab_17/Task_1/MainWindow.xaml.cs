using System;
using System.Windows;
using System.Windows.Controls;

namespace Task_1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private Func<double, double, double> GetOperation()
        {
            var operation = ((ComboBoxItem)OperationComboBox.SelectedItem).Content.ToString();
            switch (operation)
            {
                case "Додавання":
                    return (x, y) => x + y;
                case "Множення":
                    return (x, y) => x * y;
                case "Віднімання":
                    return (x, y) => x - y;
                case "Ділення":
                    return (x, y) => y != 0 ? x / y : 0;
                default:
                    return null;
            }
        }
        
        private static double Calculate(Func<double, double, double> operation, double x, double y)
        {
            return operation(x, y);
        }
        
        private Func<double, Func<double, double>> CalculateCurry(Func<double, double, double> operation)
        {
            return x => y => operation(x, y);
        }
        
        


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var operation = GetOperation();
            var x = Convert.ToDouble(XTextBox.Text);
            var y = Convert.ToDouble(YTextBox.Text);
            var result = Calculate(operation, x, y);
            ResultLabel.Content = "Result: " + result;
        }
        
        private void CalculateCurryButton_Click(object sender, RoutedEventArgs e)
        {
            var operation = GetOperation();
            var x = Convert.ToDouble(XTextBox.Text);
            var y = Convert.ToDouble(YTextBox.Text);
            var result = CalculateCurry(operation)(x)(y);
            ResultLabel.Content = "Result: " + result;
        }
    }
}