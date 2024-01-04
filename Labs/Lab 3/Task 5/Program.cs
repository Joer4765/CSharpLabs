// See https://aka.ms/new-console-template for more information


using static System.Console;
using static System.Math;

const int r = 3, n = 3;
var hits = new bool[10];
var coordinates = new string[10];

for (var i = 0; i < n; i++)
{
    Write($"Enter x{i + 1}: ");
    double.TryParse(ReadLine(), out var x);
    Write($"Enter y{i + 1}: ");
    double.TryParse(ReadLine(), out var y);
    var hit = Pow(x + r, 2) + Pow(y - r, 2) <= Pow(r, 2) || x <= 2 * r && y is >= -r and <= 0;
    hits[i] = hit;
    coordinates[i] = $"{x} {y}";
    WriteLine();
}

WriteLine($"{"Number", -8}{"Coords", -8}{"Result", -10}");
for (var i = 0; i < n; i++)
{
    WriteLine($"{i + 1, -8}{coordinates[i], -8}{(hits[i] ? "Yes" : "No"), -10}");
}