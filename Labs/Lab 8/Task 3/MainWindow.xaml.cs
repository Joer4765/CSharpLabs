using System.Text.RegularExpressions;
using System.Windows;

namespace Task_3
{
    public partial class MainWindow : Window
    {
        private const string Pattern = @"(?:[\dA-F]{2}\.){3}[\dA-F]{2}";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var input = InputText.Text;
            var count = CountMatch(Pattern, input);
            CountText.Text = count.ToString();
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            var input = InputText.Text;
            var i = int.Parse(IText.Text);
            var repl = ReplText.Text;
            var output = ReplaceI(Pattern, repl, i, input);
            OutputText.Text = output;
        }

        private static int CountMatch(string pattern, string s)
        {
            var regex = new Regex(pattern);
            var matchCollection = regex.Matches(s);
            return matchCollection.Count;
        }

        private static string ReplaceI(string pattern, string repl, int i, string s)
        {
            var count = 0;
            var result = "";
            var regex = new Regex(pattern);
            var matchCollection = regex.Matches(s);
            foreach (Match match in matchCollection)
            {
                var currentMatch = regex.Match(s);
                result += s[..currentMatch.Index];
                count += 1;
                if (count == i)
                {
                    result += repl;
                }
                else
                {
                    result += match.Value;
                }
                s = s[(currentMatch.Index + match.Length)..];
            }
            return result + s;
        }
    }
}