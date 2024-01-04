using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Task_5;

public partial class MainWindow : Window
{
    private ObservableCollection<Airplane> aircraftList = new ObservableCollection<Airplane>();

    public MainWindow()
    {
        InitializeComponent();

        aircraftListBox.ItemsSource = aircraftList;
    }

    private void AddAircraftButton_Click(object sender, RoutedEventArgs e)
    {
        var brand = brandTextBox.Text;
        var model = modelTextBox.Text;
        var maxSpeed = int.Parse(maxSpeedTextBox.Text);
        var maxAltitude = int.Parse(maxAltitudeTextBox.Text);

        var aircraft = new Airplane(brand, model, maxSpeed, maxAltitude);

        aircraftList.Add(aircraft);
    }

    private void AddBomberButton_Click(object sender, RoutedEventArgs e)
    {
        var brand = brandTextBox.Text;
        var model = modelTextBox.Text;
        var maxSpeed = int.Parse(maxSpeedTextBox.Text);
        var maxAltitude = int.Parse(maxAltitudeTextBox.Text);
        var pilotName = pilotNameTextBox.Text;

        var bomber = new Bomber(brand, model, maxSpeed, maxAltitude, pilotName);

        aircraftList.Add(bomber);
    }

    private void AddFighterButton_Click(object sender, RoutedEventArgs e)
    {
        var brand = brandTextBox.Text;
        var model = modelTextBox.Text;
        var maxSpeed = int.Parse(maxSpeedTextBox.Text);
        var maxAltitude = int.Parse(maxAltitudeTextBox.Text);
        var missionType = ((ComboBoxItem)missionTypeComboBox.SelectedItem).Content.ToString();

        var fighter = new Fighter(brand, model, maxSpeed, maxAltitude, missionType);

        aircraftList.Add(fighter);
    }
}