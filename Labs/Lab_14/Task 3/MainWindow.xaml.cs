using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_3
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var set1Input = Set1TextBox.Text;
            var set2Input = Set2TextBox.Text;

            try
            {
                // Parse user input into sets of unique elements
                var set1 = new HashSet<char>(set1Input);
                var set2 = new HashSet<char>(set2Input);

                // Perform set operations based on the selected operation
                HashSet<char> resultSet = null;
                switch (OperationComboBox.SelectedIndex)
                {
                    case 0:
                        resultSet = new HashSet<char>(set1.Intersect(set2));
                        break;
                    case 1:
                        resultSet = new HashSet<char>(set1.Union(set2));
                        break;
                    case 2:
                        resultSet = new HashSet<char>(set1.Except(set2));
                        break;
                    case 3:
                        set1.SymmetricExceptWith(set2);
                        break;
                }

                // Display the result
                if (resultSet != null) ResultLabel.Content = "Result: " + string.Join(", ", resultSet);
            }
            catch (Exception)
            {
                ResultLabel.Content = "Invalid input. Please enter valid sets.";
            }
        }
    }
}