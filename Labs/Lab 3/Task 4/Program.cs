// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter angle in radians: ");

double x = double.Parse(ReadLine()!) % Sqrt(3), add;
Write("Enter e: ");
double.TryParse(ReadLine(), out var e);

double arcctg = PI / 2, prevSum;
var i = 0;
WriteLine($"{"Argument",-10}{"Function",-10}{"Additions",-10}");
do
{
    add = Pow(-1, i + 1) * Pow(x, 2 * i + 1) / (2 * i + 1);
    arcctg += add;
    ++i;
    WriteLine($"{x,-10}{arcctg * 180 / PI,-10:F2}{i,-10:D3}");
}
while(Abs(add) > e * Abs(arcctg));

WriteLine($"Taylor: {arcctg * 180 / PI}");
WriteLine($"Function: {Atan(1 / x) * 180 / PI}");
