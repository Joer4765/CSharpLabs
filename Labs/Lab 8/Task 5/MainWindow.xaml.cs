using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void FuncButton_Click(object sender, RoutedEventArgs e)
    {
        string input = InputText.Text;

        // Split the text into words
        MatchCollection matches = Regex.Matches(input, @"\b\w+\b");

        // Create a dictionary to store words by length
        Dictionary<int, string> wordDict = new Dictionary<int, string>();
        foreach (Match match in matches)
        {
            string word = match.Value;
            int wordLength = word.Length;
            if (!wordDict.ContainsKey(wordLength))
            {
                wordDict[wordLength] = "";
            }
            wordDict[wordLength] += word + " ";
        }

        // Find the longest chain of words with the same length
        string longestChain = "";
        foreach (int wordLength in wordDict.Keys)
        {
            string chain = wordDict[wordLength].Trim();
            if (chain.Length > longestChain.Length)
            {
                longestChain = chain;
            }
        }

        OutputText.Text = longestChain;
    }
}