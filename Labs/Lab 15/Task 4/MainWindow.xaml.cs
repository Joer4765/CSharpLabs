using System.Collections;
using System.Linq;
using System.Windows;

namespace Task_4
{
    
    public struct Sklad
    {
        public string Name;
        public string Type;
        public int Quantity;
        public double Cost;
    }
    
    public partial class MainWindow
    {
        private ArrayList _shop = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Sklad newSklad;
            newSklad.Name = NameTextBox.Text;
            newSklad.Type = TypeTextBox.Text;
            newSklad.Quantity = int.Parse(QuantityTextBox.Text);
            newSklad.Cost = double.Parse(CostTextBox.Text);

            _shop.Add(newSklad);
            var strings = _shop.ToArray();

            var theString = string.Join(" ", strings);
            ResultTextBox.Text = theString;
            MessageBox.Show("Товар додано");
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var count = _shop.Count;
            MessageBox.Show($"Кількість елементів у масиві: {count}");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _shop.Clear();
            var strings = _shop.ToArray();

            var theString = string.Join(" ", strings);
            ResultTextBox.Text = theString;
            MessageBox.Show("Масив очищено");
        }
    }
}