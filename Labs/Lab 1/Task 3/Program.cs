// See https://aka.ms/new-console-template for more information

using static System.Console;

Write("Enter 5 digit number: ");
int.TryParse(ReadLine(), out var n);
WriteLine($"Sum of 2d and 3d number = {n / 1000 % 10 + n / 100 % 10}");
