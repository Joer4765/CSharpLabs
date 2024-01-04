namespace Task_2
    {
    using System;

    public enum Months
    {
        Січень = 1,
        Лютий,
        Березень,
        Квітень,
        Травень,
        Червень,
        Липень,
        Серпень,
        Вересень,
        Жовтень,
        Листопад,
        Грудень
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var userInput = 1;
            while (userInput != 0)
            {
                Console.WriteLine("Введіть номер місяця (1-12) або 0 для виходу:");
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case (int)Months.Січень:
                        Console.WriteLine("Січень - пуховик");
                        break;
                    case (int)Months.Лютий:
                        Console.WriteLine("Лютий - шарф");
                        break;
                    case (int)Months.Березень:
                        Console.WriteLine("Березень - демісезонний плащ");
                        break;
                    case (int)Months.Квітень:
                        Console.WriteLine("Квітень - весняна куртка");
                        break;
                    case (int)Months.Травень:
                        Console.WriteLine("Травень - джинсова куртка");
                        break;
                    case (int)Months.Червень:
                        Console.WriteLine("Червень - футболка");
                        break;
                    case (int)Months.Липень:
                        Console.WriteLine("Липень - шорти");
                        break;
                    case (int)Months.Серпень:
                        Console.WriteLine("Серпень - сандалі");
                        break;
                    case (int)Months.Вересень:
                        Console.WriteLine("Вересень - светр");
                        break;
                    case (int)Months.Жовтень:
                        Console.WriteLine("Жовтень - осіння куртка");
                        break;
                    case (int)Months.Листопад:
                        Console.WriteLine("Листопад - теплий светр");
                        break;
                    case (int)Months.Грудень:
                        Console.WriteLine("Грудень - зимова куртка");
                        break;
                    default:
                        if(userInput != 0)
                            Console.WriteLine("Невірний ввід, спробуйте ще раз.");
                        break;
                }
            }
            Console.WriteLine("Програма завершила роботу.");
        }
    }
}