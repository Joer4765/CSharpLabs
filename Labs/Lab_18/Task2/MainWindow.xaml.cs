using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;

namespace Task2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadDataButtonClick(object sender, RoutedEventArgs e)
        {
            // Clear previous results
            lvResults.Items.Clear();

            // Read data from input.txt
            string inputText = File.ReadAllText("input.txt");

            // Recognize ordinal numbers
            var results = RecognizeOrdinalNumbers(inputText);

            // Display results in the ListView
            foreach (var result in results)
            {
                lvResults.Items.Add(new { Original = result.Text, NumericFormat = result.Resolution["value"] });
            }

            // Display the count of ordinal numbers
            MessageBox.Show($"Number of ordinal numbers: {results.Count}");

            // Save results to a file
            SaveResultsToFile(results);
        }

        private List<ModelResult> RecognizeOrdinalNumbers(string inputText)
        {
            var results = NumberRecognizer.RecognizeOrdinal(inputText, Culture.English);
            return results.ToList();
        }

        private void SaveResultsToFile(List<ModelResult> results)
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (var result in results)
                {
                    sw.WriteLine($"{result.Text} – {result.Resolution["value"]}");
                }
            }
        }
    }
}