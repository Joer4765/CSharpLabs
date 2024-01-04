using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Task_2
{
    public partial class MainWindow : Window
    {
        // Define the input and output file paths as constants
        private const string InputFile = "TF_1.txt";
        private const string OutputFile = "TF_2.txt";

        public MainWindow()
        {
            InitializeComponent();
            // Create the input file when the window is initialized
            CreateFile(InputFile);
        }

        // Method to create the input file with some sample text
        private void CreateFile(string inputFilePath)
        {
            using (var writer = new StreamWriter(inputFilePath))
            {
                writer.WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce malesuada auctor ipsum, vel accumsan odio tincidunt a. Sed semper nisl eget nisi commodo, a consectetur dolor hendrerit. Nunc eu sapien euismod, imperdiet quam ac, fringilla turpis. Duis non diam non nisl pellentesque convallis. Sed semper turpis vel velit elementum malesuada. Sed vulputate auctor nisi, sed posuere lorem tincidunt vel. Suspendisse semper ultrices dolor, vel elementum eros lacinia eu. Ut rutrum massa vel risus vestibulum, ac tincidunt quam vehicula. Sed mollis aliquet erat ut commodo. Mauris ornare eget enim id faucibus. Vivamus interdum risus sed felis accumsan, ac suscipit elit dictum.");
            }
            // Enable the "Process file" button after the input file has been created
            ProcessFileButton.IsEnabled = true;
        }

        // Method to process the input file and write the output to a new file
        private void ProcessFile(string inputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            using (var writer = new StreamWriter(OutputFile))
            {
                var text = reader.ReadToEnd();
                // Use regular expressions to find all words in the text
                var words = Regex.Matches(text, @"\b\w+\b").Select(m => m.Value);
                // Filter the words to only include those that contain the letter 'a'
                var wordsWithA = words.Where(w => w.Contains('a'));
                var withA = wordsWithA as string[] ?? wordsWithA.ToArray();
                if (withA.Any())
                {
                    // Write the words that contain 'a' to the output file, one per line
                    writer.WriteLine(string.Join(Environment.NewLine, withA));
                }
                else
                {
                    // If no words with 'a' were found, write a message to the output file
                    writer.WriteLine("No words with 'a' found in the file.");
                }
            }
            // Read the contents of the output file and display it in a label
            using (var reader = new StreamReader(OutputFile))
            {
                OutputLabel.Content = reader.ReadToEnd();
            }
        }

        // Event handler for when the "Process file" button is clicked
        private void ProcessFileButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessFile(InputFile);
        }

        // Event handler for when the "Quit" button is clicked
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}