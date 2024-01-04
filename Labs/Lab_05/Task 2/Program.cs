// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter n: ");
int.TryParse(ReadLine(), out var n);
var arr = new int[n];
var rand = new Random();
for (var i = 0; i < n; i++)
{
    arr[i] = rand.Next(-9, 10);
    Write($"{arr[i]} ");
}
WriteLine();
var max = arr.Max();
WriteLine($"max = {max}");
var maxI = Array.IndexOf(arr, max);
WriteLine($"max index = {maxI}");
var min = arr.Min();
WriteLine($"min = {min}");
var minI = Array.IndexOf(arr, min);
WriteLine($"min index = {minI}");
var sum = arr[Min(minI, maxI)..(Max(minI, maxI) + 1)].Sum();
WriteLine($"sum = {sum}");

