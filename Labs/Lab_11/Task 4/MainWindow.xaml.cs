using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Task_4;

public partial class MainWindow : Window
{
    private readonly List<SatelliteDish> dishes = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var diameter = double.Parse(diameterTextBox.Text);
        var material = materialTextBox.Text;
        var price = double.Parse(priceTextBox.Text);
        var suspensionType = (string)((ComboBoxItem)suspensionTypeComboBox.SelectedItem).Content;

        SatelliteDish dish = new SatelliteDishChild(diameter, material, price, suspensionType);
        dishes.Add(dish);

        dishListBox.Items.Add(dish.ToString());
    }
}