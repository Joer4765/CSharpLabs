using System.Collections.Generic;
using System.Windows;

namespace Task_4
{
    public partial class MainWindow
    {
        private readonly Dictionary<string, string> _myDictionary = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddElement_Click(object sender, RoutedEventArgs e)
        {
            var key = KeyTextBox.Text;
            var value = ValueTextBox.Text;

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;
            _myDictionary[key] = value;
            UpdateDisplay();
        }

        private void RemoveElement_Click(object sender, RoutedEventArgs e)
        {
            var key = KeyTextBox.Text;

            if (!string.IsNullOrEmpty(key) && _myDictionary.ContainsKey(key))
            {
                _myDictionary.Remove(key);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Key not found in dictionary", "Error");
            }
        }

        private void GetCount_Click(object sender, RoutedEventArgs e)
        {
            var count = _myDictionary.Count;
            CountLabel.Content = $"Count: {count}";
        }

        private void ClearDictionary_Click(object sender, RoutedEventArgs e)
        {
            _myDictionary.Clear();
            UpdateDisplay();
        }

        private void CheckKey_Click(object sender, RoutedEventArgs e)
        {
            var key = KeyTextBox.Text;

            if (!string.IsNullOrEmpty(key) && _myDictionary.ContainsKey(key))
            {
                MessageBox.Show("Key exists in dictionary", "Key Exist");
            }
            else
            {
                MessageBox.Show("Key does not exist in dictionary", "Key Does Not Exist");
            }
        }

        private void CheckValue_Click(object sender, RoutedEventArgs e)
        {
            var value = ValueTextBox.Text;

            if (!string.IsNullOrEmpty(value) && _myDictionary.ContainsValue(value))
            {
                MessageBox.Show("Value exists in dictionary", "Value Exist");
            }
            else
            {
                MessageBox.Show("Value does not exist in dictionary", "Value Does Not Exist");
            }
        }

        private void UpdateDisplay()
        {
            ResultTextBlock.Text = string.Empty;
            foreach (var kvp in _myDictionary)
            {
                ResultTextBlock.Text += $"{kvp.Key}: {kvp.Value}\n";
            }
        }
    }
}
