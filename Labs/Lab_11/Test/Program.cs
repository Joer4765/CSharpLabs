using Test;

var date = new Date(1, 2, 1);

namespace Test
{
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
            // MessageBox.Show("The object has been destroyed");
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



    internal class Employee: Date


    {
        private readonly string _name;
        private readonly Date _employmentDate;

        public int YearsOfWork { get; }

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

        private int CalculateYearsOfWork()
        {
            var years = DateTime.Now.Year - _employmentDate.Year;
            if (DateTime.Now.Month < _employmentDate.Month || (DateTime.Now.Month == _employmentDate.Month && DateTime.Now.Day < _employmentDate.Day))
            {
                years--;
            }
            return years;
        }
    }
}

