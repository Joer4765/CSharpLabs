using System;
using System.Globalization;
using System.Windows;

namespace Task_1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateExpiration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dateInput = DateTextBox.Text;
                var timeInput = TimeTextBox.Text;

                // Parse date and time inputs
                var lastCallDateTime = DateTime.ParseExact(dateInput + " " + timeInput, "ddMMyyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                var expirationDateTime = lastCallDateTime.AddYears(1);
                var dayOfWeek = (int)expirationDateTime.DayOfWeek + 1; // 1 - Monday

                ResultLabel.Text = $"Expiration Date and Time: {expirationDateTime}";
                DayOfWeekLabel.Text = $"Day of the Week (1 - Monday): {dayOfWeek}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}