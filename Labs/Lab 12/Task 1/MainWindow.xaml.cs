using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_1;

public partial class MainWindow
{
    private List<Plant> plants = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object sender, RoutedEventArgs e)
    {
        Plant plant = null;
        var name = txtName.Text;
        var redBook = cbRedBook.IsChecked ?? false;

        if (rbTree.IsChecked ?? false)
        {
            if (int.TryParse(txtParam.Text, out var height))
            {
                plant = new Tree(name, redBook, height);
            }
            else
            {
                MessageBox.Show("Please enter a valid height value for the tree.");
                return;
            }
        }
        else if (rbFlower.IsChecked ?? false)
        {
            var color = txtParam.Text;

            if (!string.IsNullOrEmpty(color))
            {
                plant = new Flower(name, redBook, color);
            }
            else
            {
                MessageBox.Show("Please enter a color value for the flower.");
                return;
            }
        }

        if (plant == null) return;
        plants.Add(plant);
        MessageBox.Show("Plant added successfully.");
    }

    private void btnShowPlants_Click(object sender, RoutedEventArgs e)
    {
        if (plants.Count == 0)
        {
            MessageBox.Show("There are no plants to display.");
        }
        else
        {
            var plantInfo = "";

            foreach (var plant in plants)
            {
                plantInfo += plant.DisplayInfo() + "\n";
            }

            MessageBox.Show(plantInfo);
        }
    }

    private void btnSearchRedBook_Click(object sender, RoutedEventArgs e)
    {
        var found = false;
        var plantsRedBook = "Plants in the Red Book of Ukraine: ";
        
        foreach (var plant in plants.Where(plant => plant.RedBook))
        {
            found = true;
            plantsRedBook += plant.Name + ' ';
        }
        MessageBox.Show(plantsRedBook);

        if (!found)
        {
            MessageBox.Show("None of the plants are in the Red Book of Ukraine.");
        }
    }
}

public abstract class Plant
{
    public string Name { get; set; }
    public bool RedBook { get; set; }

    public Plant(string name, bool redBook)
    {
        Name = name;
        RedBook = redBook;
    }

    public abstract string DisplayInfo();
}

public class Tree : Plant
{
    public int Height { get; set; }

    public Tree(string name, bool redBook, int height) : base(name, redBook)
    {
        Height = height;
    }

    public override string DisplayInfo()
    {
        return "Tree: " + Name + ", Height: " + Height;
    }
}

public class Flower : Plant
{
    public string Color { get; set; }

    public Flower(string name, bool redBook, string color) : base(name, redBook)
    {
        Color = color;
    }

    public override string DisplayInfo()
    {
        return "Flower: " + Name + ", Color: " + Color;
    }
}