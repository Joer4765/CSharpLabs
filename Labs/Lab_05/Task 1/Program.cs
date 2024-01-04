// See https://aka.ms/new-console-template for more information
using static System.Console;
using static System.Math;

Write("Enter n: ");
int.TryParse(ReadLine(), out var n);
var array = new int[n];
var array2 = new decimal[n];
var rand = new Random();
var total = 0;

WriteLine("Input massive: ");
for (var i = 0; i < n; i++)
{
    array[i] = rand.Next(-9, 10);
    Write($"{array[i]} ");
    total += array[i];
}
WriteLine();
var avg = total / Convert.ToDecimal(n);
WriteLine($"avg = {avg}");
WriteLine("Output massive: ");
for (var i = 0; i < n; i++)
{
    array2[i] = Round(array[i] - avg, 2);
    Write($"{array2[i]} ");
}