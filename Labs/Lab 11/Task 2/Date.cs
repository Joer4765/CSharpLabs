using System;
using System.Windows;

namespace Task_2;

public class Date
{
    public int Day { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }

    protected Date()
    {
        Day = 1;
        Month = 1;
        Year = 2022;
    }

    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    ~Date()
    {
        MessageBox.Show("The object has been destroyed");
    }

    public string GetInfo()
    {
        return $"{Day}/{Month}/{Year}";
    }

    public void IncreaseYear()
    {
        Year++;
    }

    public void DecreaseDate()
    {
        Day -= 2;
        if (Day >= 1) return;
        Month--;
        if (Month < 1)
        {
            Month = 12;
            Year--;
        }
        Day += DateTime.DaysInMonth(Year, Month);
    }
}