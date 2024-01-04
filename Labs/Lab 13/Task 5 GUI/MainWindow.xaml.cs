using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_5_GUI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримати значення з текстових полів
            var studentName = StudentNameTextBox.Text;
            var homeworkScoresText = HomeworkScoresTextBox.Text;
            var examScoreText = ExamScoreTextBox.Text;

            // Розбити рядок оцінок за домашні завдання на масив чисел
            var homeworkScoresArray = homeworkScoresText.Split(',');
            var homeworkScoresIntArray = new List<int>();

            foreach (var score in homeworkScoresArray)
            {
                if (int.TryParse(score, out var parsedScore))
                {
                    homeworkScoresIntArray.Add(parsedScore);
                }
                else
                {
                    MessageBox.Show("Помилка введення оцінок за домашні завдання.");
                    return;
                }
            }

            var homeworkScoresTuple = Tuple.Create(homeworkScoresIntArray[0], homeworkScoresIntArray[1], homeworkScoresIntArray[2],
                homeworkScoresIntArray[3], homeworkScoresIntArray[4], homeworkScoresIntArray[5]);

            // Перевірка правильності введення оцінки за іспит
            if (!int.TryParse(examScoreText, out var examScore))
            {
                MessageBox.Show("Помилка введення оцінки за іспит.");
                return;
            }

            // Виведення результату
            ResultLabel.Content = GetScore(studentName, homeworkScoresTuple, examScore);

        }
        
        private static string GetScore(string student, Tuple<int, int, int, int, int, int> homeWork, int exam)
        {
            var hwAverage = homeWork.Item1 + homeWork.Item2 + homeWork.Item3 + homeWork.Item4 + homeWork.Item5 +
                            homeWork.Item6 / 6;
            var grade = (int)Math.Round(0.4 * hwAverage + 0.6 * exam);
            return $"Студент {student} – ваша підсумкова оцінка за іспит {grade}";
        }
    }
}