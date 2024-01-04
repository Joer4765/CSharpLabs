// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter x: ");
int.TryParse(ReadLine(), out var x);

double sum = 0;
for (var i = 1; i <= 40; i++)
{
    sum += Pow(i, 2) * Pow(E, -Sqrt(3 * i - x));
}

WriteLine($"sum = {sum}");