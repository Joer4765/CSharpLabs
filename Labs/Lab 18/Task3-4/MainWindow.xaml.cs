using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.Sequence;

namespace Task3;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ProcessFileButton_Click(object sender, RoutedEventArgs e)
    {
        // Отримання шляху до текстового файлу
        const string filePath = "input.txt";

        if (File.Exists(filePath))
        {
            ResultsTextBox.Text = "";
            // Зчитування тексту з файлу
            var fileContent = File.ReadAllText(filePath);
            
            // Розпізнавання валюти
            var currencyResults = NumberWithUnitRecognizer.RecognizeCurrency(fileContent, Culture.English);
            DisplayResults("Currency", currencyResults);

            // Розпізнавання розміру, ваги, відстані, маси
            var dimensionResults = NumberWithUnitRecognizer.RecognizeDimension(fileContent, Culture.English);
            DisplayResults("Dimension", dimensionResults);

            // Розпізнавання температури
            var temperatureResults = NumberWithUnitRecognizer.RecognizeTemperature(fileContent, Culture.English);
            DisplayResults("Temperature", temperatureResults);

            // Розпізнавання дати і часу
            var dateTimeResults = DateTimeRecognizer.RecognizeDateTime(fileContent, Culture.English);
            DisplayData("DateTime", dateTimeResults);
            
            RecognizeSequences(fileContent);

            // Збереження результатів у файл
            SaveResultsToFile(filePath + "_results.txt");
            
        }
        else
        {
            MessageBox.Show("File not found!");
        }
    }

    private void DisplayResults(string category, List<ModelResult> results)
    {
           
        // Виведення результатів на форму
        ResultsTextBox.Text += $"--- {category} ---\n";

        foreach (var result in results)
        {
            ResultsTextBox.Text += $"Text: {result.Text}, Value: {result.Resolution["value"]}\n";
        }

        ResultsTextBox.Text += "\n";

        // Підрахунок та виведення кількості розпізнаних значень
        int count = results.Count;
        CountTextBox.Text += $"{category}: {count}\n";
    }

    private void SaveResultsToFile(string filePath)
    {
        // Збереження результатів у файл
        File.WriteAllText(filePath, ResultsTextBox.Text);
        MessageBox.Show($"Results saved to {filePath}");
    }
        
    private void DisplayData(string category, List<ModelResult> results)
    {
           
        // Виведення результатів на форму
        ResultsTextBox.Text += $"--- {category} ---\n";

        foreach (var result in results)
        {
            var innerDictionary = result.Resolution["values"] as List<Dictionary<string, string>>;
            if (innerDictionary?[0]["type"] == "timerange")
            {
                ResultsTextBox.Text += $"Text: {result.Text}, Value: {innerDictionary[0]["start"]}-{innerDictionary[0]["end"]}\n";
            }
            else
            {
                ResultsTextBox.Text += $"Text: {result.Text}, Value: {innerDictionary?[0]["value"]}\n";
            }
                
        }

        ResultsTextBox.Text += "\n";

        // Підрахунок та виведення кількості розпізнаних значень
        int count = results.Count;
        CountTextBox.Text += $"{category}: {count}\n";
    }
        
        
    private void ReadDataButton_Click(object sender, RoutedEventArgs e)
    {
        const string filePath = "input.txt";

        if (File.Exists(filePath))
        {
            DataTextBox.Text = "";
            var fileContent = File.ReadAllText(filePath);
            DataTextBox.Text = fileContent;
        }
        else
        {
            MessageBox.Show("File not found!");
        }
    }

    private void RecognizeSequences(string text)
    {
        // Розпізнавання номера телефону
        var phoneNumbers = SequenceRecognizer.RecognizePhoneNumber(text, Culture.English);
        DisplayResults("Phone Numbers", phoneNumbers);

        // Розпізнавання IP-адрес
        var ipAddresses = SequenceRecognizer.RecognizeIpAddress(text, Culture.English);
        DisplayResults("IP Addresses", ipAddresses);

        // Розпізнавання адрес електронної пошти
        var emails = SequenceRecognizer.RecognizeEmail(text, Culture.English);
        DisplayResults("Email Addresses", emails);

        // Розпізнавання URL-адрес
        var urls = SequenceRecognizer.RecognizeURL(text, Culture.English);
        DisplayResults("URL Addresses", urls);

        // Розпізнавання хеш-тегів
        var hashtags = SequenceRecognizer.RecognizeHashtag(text, Culture.English);
        DisplayResults("Hashtags", hashtags);
    }
}