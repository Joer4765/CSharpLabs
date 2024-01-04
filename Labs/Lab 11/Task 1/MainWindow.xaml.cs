using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_1;

class MovingObject
{
    private double speed; 
    private int time;     

    public MovingObject(double speed, int time)
    {
        this.speed = speed;
        this.time = time;
    }

    public string GetInfo()
    {
        return $"Speed: {speed} m/s, Time: {time} min";
    }

    public double CalculateDistance()
    {
        return speed * (time * 60);
    }
}


internal class MovingObjectChild : MovingObject
{
    private double force;

    public MovingObjectChild(double speed, int time, double force) : base(speed, time)
    {
        this.force = force;
    }

    public double CalculateWork()
    {
        var distance = CalculateDistance();
        return force * distance;
    }
}

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        var obj = new MovingObjectChild(
            double.Parse(SpeedTextBox.Text),
            int.Parse(TimeTextBox.Text),
            double.Parse(ForceTextBox.Text)
        );
        ResultTextBlock.Text = $"Distance: {obj.CalculateDistance()} m, Work: {obj.CalculateWork()} J";
    }
}

