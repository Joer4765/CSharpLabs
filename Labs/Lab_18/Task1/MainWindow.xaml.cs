using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;

namespace Lab_18
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadData_Click(object sender, RoutedEventArgs e)
        {
            // Call a method to read data from input.txt and populate the TextBox
            ReadDataFromFile("input.txt");
        }

        private void ReadDataFromFile(string fileName)
        {
            try
            {
                // Read data from the file and set it to the TextBox
                string fileContent = File.ReadAllText(fileName);
                txtResults.Text = fileContent;

                MessageBox.Show($"Data loaded from {fileName}", "Read Data", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RecognizeNumbers_Click(object sender, RoutedEventArgs e)
        {
            string inputText = txtResults.Text; // Read from TextBox instead of TextBox
            List<ModelResult> results = RecognizeNumbers(inputText);

            DisplayResults(results);
            SaveResultsToFile(results, "output.txt");
        }

        private List<ModelResult> RecognizeNumbers(string text)
        {
            var results = NumberRecognizer.RecognizeNumber(text, Culture.English);
            return results;
        }

        private void DisplayResults(List<ModelResult> results)
        {
            txtResults.Text = "";

            foreach (var result in results)
            {
                txtResults.Text += $"Розпізнаний текст: {result.Text}\n";
                txtResults.Text += $"Початковий індекс у рядку: {result.Start}\n";
                txtResults.Text += $"Кінцевий індекс у рядку: {result.End}\n";
                txtResults.Text += $"Розпізнане значення: {result.Resolution["value"]}\n\n";
            }
        }

        private void SaveResultsToFile(List<ModelResult> results, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var result in results)
                    {
                        sw.WriteLine($"Розпізнаний текст: {result.Text}");
                        sw.WriteLine($"Початковий індекс у рядку: {result.Start}");
                        sw.WriteLine($"Кінцевий індекс у рядку: {result.End}");
                        sw.WriteLine($"Розпізнане значення: {result.Resolution["value"]}\n");
                    }
                }

                MessageBox.Show($"Results saved to {fileName}", "Save Results", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving results: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
