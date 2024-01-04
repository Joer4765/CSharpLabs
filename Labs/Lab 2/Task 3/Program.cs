// See https://aka.ms/new-console-template for more information

using static System.Console;

Write("Enter m: ");
int.TryParse(ReadLine(), out var m);

switch (m % 12)
{
    case 0:
        WriteLine("January");
        break;
    case 1:
        WriteLine("February");
        break;
    case 2:
        WriteLine("March");
        break;
    case 3:
        WriteLine("April");
        break;
    case 4:
        WriteLine("May");
        break;
    case 5:
        WriteLine("June");
        break;
    case 6:
        WriteLine("July");
        break;
    case 7:
        WriteLine("August");
        break;
    case 8:
        WriteLine("September");
        break;
    case 9:
        WriteLine("October");
        break;
    case 10:
        WriteLine("November");
        break;
    case 11:
        WriteLine("December");
        break;
}