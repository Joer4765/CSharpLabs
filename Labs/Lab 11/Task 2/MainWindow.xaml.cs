using System.Windows;

namespace Task_2;

public partial class MainWindow
{
    private Date _date;
    private Employee? _employee;
        
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SetEmployee_Click(object sender, RoutedEventArgs e)
    {
        _date = new Date(int.Parse(DayTextBox.Text), int.Parse(MonthTextBox.Text),int.Parse(YearTextBox.Text));
        _employee = new Employee(NameTextBox.Text, _date);
        EmployeeInfoBlock.Text = _employee?.GetEmployeeInfo();
    }

    private void IncreaseYearButton_Click(object sender, RoutedEventArgs e)
    {
        _date.IncreaseYear();
        _employee?.CalculateYearsOfWork();
        EmployeeInfoBlock.Text = _employee?.GetEmployeeInfo();
    }
    
    private void DecreaseDateButton_Click(object sender, RoutedEventArgs e)
    {
        _date.DecreaseDate();
        _employee?.CalculateYearsOfWork();
        EmployeeInfoBlock.Text = _employee?.GetEmployeeInfo();
    }
}