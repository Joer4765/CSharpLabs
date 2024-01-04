using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_4_GUI
{
    public partial class MainWindow
    {
        private readonly List<Tuple<string, double, string, double>> _productData = new List<Tuple<string, double, string, double>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var name = nameTextBox.Text;
            var price = Convert.ToDouble(priceTextBox.Text);
            var category = categoryTextBox.Text;
            var demand = Convert.ToDouble(demandTextBox.Text);
            
            var newProduct = Tuple.Create(name, price, category, demand);
            _productData.Add(newProduct);

            productListView.Items.Add(newProduct);

            nameTextBox.Clear();
            priceTextBox.Clear();
            categoryTextBox.Clear();
            demandTextBox.Clear();
        }

        private void Analyze_Click(object sender, RoutedEventArgs e)
        {
            var averagePrice = _productData.Sum(product => product.Item2);

            averagePrice /= _productData.Count;

            var socialProductsCount = _productData.Count(product => product.Item2 < averagePrice);

            resultLabel.Content = $"Кількість продуктів у соціальній категорії: {socialProductsCount}";
        }
    }
}