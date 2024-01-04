using System.Collections.Generic;

namespace Task_5
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetScore("Melnyk", new int[] {90, 85, 88, 92, 86, 87}, 91));
        }

        private static string GetScore(string student, IEnumerable<int> homeWork, int exam)
        {
            var hwAverage = homeWork.Average();
            var grade = (int)Math.Round(0.4 * hwAverage + 0.6 * exam);
            return $"Студент {student} – ваша підсумкова оцінка за іспит {grade}";
        }
    }

}