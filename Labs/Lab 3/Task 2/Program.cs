// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter limit for k: ");
long.TryParse(ReadLine(), out var limit);
var overflow = false;

double sum = 0;
for (var x = 1; x <= 5; x++)
{
    for (var k = 1; k <= limit; k++)
    {
        var add = Pow(-1, k) * Pow(x, 2 * k) / (x * (k + 1) * (k + 2));
        if (double.IsInfinity(sum + add))
        {
            WriteLine($"Reached double type limit at k = {k}");
            overflow = true;
            break;
        }

        sum += add;

    }
    if (overflow)
        break;
}

WriteLine($"sum = {sum}");