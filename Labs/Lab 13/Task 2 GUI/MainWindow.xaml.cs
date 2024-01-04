using System.Windows;

public enum Months
{
    Січень = 1,
    Лютий,
    Березень,
    Квітень,
    Травень,
    Червень,
    Липень,
    Серпень,
    Вересень,
    Жовтень,
    Листопад,
    Грудень
}

namespace Task_2_GUI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(inputTextBox.Text, out var userInput))
            {
                switch (userInput)
                {
                    case 0:
                        Close();
                        break;
                    case (int)Months.Січень:
                        resultTextBlock.Text = "Січень - пуховик";
                        break;
                    case (int)Months.Лютий:
                        resultTextBlock.Text = "Лютий - шарф";
                        break;
                    case (int)Months.Березень:
                        resultTextBlock.Text = "Березень - демісезонний плащ";
                        break;
                    case (int)Months.Квітень:
                        resultTextBlock.Text = "Квітень - весняна куртка";
                        break;
                    case (int)Months.Травень:
                        resultTextBlock.Text = "Травень - джинсова куртка";
                        break;
                    case (int)Months.Червень:
                        resultTextBlock.Text = "Червень - футболка";
                        break;
                    case (int)Months.Липень:
                        resultTextBlock.Text = "Липень - шорти";
                        break;
                    case (int)Months.Серпень:
                        resultTextBlock.Text = "Серпень - сандалі";
                        break;
                    case (int)Months.Вересень:
                        resultTextBlock.Text = "Вересень - светр";
                        break;
                    case (int)Months.Жовтень:
                        resultTextBlock.Text = "Жовтень - осіння куртка";
                        break;
                    case (int)Months.Листопад:
                        resultTextBlock.Text = "Листопад - теплий светр";
                        break;
                    case (int)Months.Грудень:
                        resultTextBlock.Text = "Грудень - зимова куртка";
                        break;
                    default:
                        resultTextBlock.Text = "Невірний ввід, спробуйте ще раз.";
                        break;
                }
            }
            else
            {
                resultTextBlock.Text = "Невірний ввід, спробуйте ще раз.";
            }
        }
    }
}