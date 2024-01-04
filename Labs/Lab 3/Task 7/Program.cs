// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter grain weight: ");
double.TryParse(ReadLine(), out var weight);

double sum = 0;
WriteLine("1 grain for 1 cell");
for (var i = 1; i < 64; i++)
{
    double grains = Pow(2, i);
    sum += grains;
    WriteLine($"{grains:N} grains for {i + 1} cells");
}
WriteLine();
WriteLine($"{sum:N} — grains total count");
WriteLine($"{sum * weight:N} — grains total weight ");