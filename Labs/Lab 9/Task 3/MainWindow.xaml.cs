using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Task_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            const string filepath = "TF_3.txt";
            var text = File.ReadAllText(filepath);
            var longestWords = FindLongestWords(text);
            if (longestWords.Length > 0)
            {
                var updatedText = ReplaceChars(text, longestWords);
                SaveFile(updatedText);
                MessageLabel.Content = $"The longest words in the file are \"{string.Join(", ", longestWords)}\"";
            }
            else
            {
                MessageLabel.Content = "There are no words in the file";
            }
        }

        private static string[] FindLongestWords(string text)
        {
            var words = Regex.Matches(text, @"\b\w+\b").Select(m => m.Value).ToArray();
            var maxLength = 0;
            foreach (var word in words)
            {
                if (word.Length > maxLength)
                    maxLength = word.Length;
            }
            return words.Where(word => word.Length == maxLength).ToArray();
        }

        private static string ReplaceChars(string text, string[] words)
        {
            foreach (var word in words)
            {
                text = text.Replace(word, new string('#', word.Length));
            }
            return text;
        }

        private static void SaveFile(string text)
        {
            const string filepath = "TF_4.txt";
            File.WriteAllText(filepath, text);
        }
    }
}