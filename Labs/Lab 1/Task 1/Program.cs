// See https://aka.ms/new-console-template for more information
using static System.Console;
using static System.Math;

WriteLine("Enter m: ");
double.TryParse(ReadLine(), out var m);
WriteLine("Enter y: ");
double.TryParse(ReadLine(), out var y);
WriteLine($"result = {(Pow(m, 2) + 2.8 * m + 0.355) / (Cos(2*y) + 3.6)}");
