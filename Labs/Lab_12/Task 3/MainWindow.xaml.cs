using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows;

namespace Task_3;


public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private readonly List<Worker> workers = new();

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        workers.Add(new Worker(TxtName.Text, int.Parse(TxtAge.Text), int.Parse(TxtSalary.Text)));
        Output.Text = GetInfo();
    }
    
    private void Sort_Click(object sender, RoutedEventArgs e)
    {
        workers.Sort(new SortBySalary());
        Output.Text = GetInfo();
    }
    
    private string GetInfo()
    {
        var result = "";
        foreach (var worker in workers)
        {
            result += $"Name: {worker.Name}, Age: {worker.Age}, Salary: {worker.Salary}\n";
        }

        return result;
    }
}

public class Worker : IComparable<Worker>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }

    public Worker(string name, int age, decimal salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }
    

    public int CompareTo(Worker other)
    {
        return Age.CompareTo(other.Age);
    }
}

public class SortBySalary : IComparer<Worker>
{
    public int Compare(Worker x, Worker y)
    {
        return x.Salary.CompareTo(y.Salary);
    }
}


public class Workers : IEnumerable<Worker>
{
    private readonly List<Worker> _workers = new();

    public void Add(Worker worker)
    {
        _workers.Add(worker);
    }

    public IEnumerator<Worker> GetEnumerator()
    {
        return _workers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
