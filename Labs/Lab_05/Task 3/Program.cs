// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter n: ");
int.TryParse(ReadLine(), out var n);
double[] x = new double[n], y = new double[n], r  = new double[n + n % 2];
var rand = new Random();
for (var i = 0; i < n; i++)
{
    x[i] = Round(rand.NextDouble() * 10, 2);
    if (Cos(x[i]) > 0)
        y[i] = Pow(x[i], 3) - 7.5;
    else
        y[i] = Pow(x[i], 2) - 5 * Pow(E, Sin(x[i]));
    if (i % 2 == 0)
    {
        r[i] = x[i];
        r[i + 1] = y[i];
        Write($"{r[i]} {r[i + 1]} ");
    }
}
WriteLine();


    