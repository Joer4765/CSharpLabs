// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter diagonal: ");
double.TryParse(ReadLine(), out var d);
WriteLine($"Square = {Pow(d, 2) / 2}");
WriteLine($"Perimeter = {2 * d * Sqrt(2)}");