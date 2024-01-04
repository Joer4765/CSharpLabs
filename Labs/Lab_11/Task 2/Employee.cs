using System;

namespace Task_2;

internal class Employee: Date
{
    private readonly string _name;
    private readonly Date _employmentDate;
    private int YearsOfWork { get; set; }

    public Employee(string name, Date employmentDate)
    {
        _name = name;
        _employmentDate = employmentDate;
        YearsOfWork = CalculateYearsOfWork();
    }

    public string GetEmployeeInfo()
    {
        return $"Employee {_name}, employed on {_employmentDate.GetInfo()}. Years of work: {YearsOfWork}";
    }

    public int CalculateYearsOfWork()
    {
        YearsOfWork = DateTime.Now.Year - _employmentDate.Year;
        if (DateTime.Now.Month < _employmentDate.Month || (DateTime.Now.Month == _employmentDate.Month && DateTime.Now.Day < _employmentDate.Day))
        {
            YearsOfWork--;
        }
        
        return YearsOfWork;
    }
}