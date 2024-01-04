using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Task_1;

public struct Sklad
{
    public string Name;
    public string Type;
    public int Quantity;
    public double Cost;
}

public partial class MainWindow
{
    private List<Sklad> _shop = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        // Додавання нового товару до списку
        Sklad newSklad;
        newSklad.Name = NameTextBox.Text;
        newSklad.Type = TypeTextBox.Text;
        newSklad.Quantity = int.Parse(QuantityTextBox.Text);
        newSklad.Cost = double.Parse(CostTextBox.Text);
        _shop.Add(newSklad);

        // Сортування списку за назвами товарів
        _shop = _shop.OrderBy(s => s.Name).ToList();
        
        MessageBox.Show("Товар додано");
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        // Пошук товару за назвою
        var searchName = SearchTextBox.Text;
        var foundSklad = _shop.Find(s => s.Name == searchName);
        if (foundSklad.Name != null)
        {
            // Виведення інформації про товар
            ResultTextBox.Text = $"Назва: {foundSklad.Name}\nКількість: {foundSklad.Quantity}\nЦіна за одиницю: {foundSklad.Cost}\nЗагальна сума: {foundSklad.Quantity * foundSklad.Cost}";
        }
        else
        {
            ResultTextBox.Text = "Товар не знайдено";
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        // Запис масиву SHOP у файл
        using (var file = new StreamWriter(@"Shop.txt"))
            foreach (var entry in _shop)
                file.WriteLine($"Назва: {entry.Name}, Тип: {entry.Type}, Кількість: {entry.Quantity}, Ціна: {entry.Cost}");
        MessageBox.Show("Збережно у файл");
    }
}