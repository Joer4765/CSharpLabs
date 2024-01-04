// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter x: ");
double.TryParse(ReadLine(), out var x);
Write("Enter e: ");
double.TryParse(ReadLine(), out var e);

var sum = 0.0;
var i = 0;
while (true)
{
    ++i;
    var factorial = 1;
    for (var j = 2; j <= i * 2; j++)
    {
        factorial *= j;
    }
    var add = Pow(-1, i - 1) * Pow(x, 2 * i) / factorial;
    if (double.IsInfinity(sum + add) || Abs(add) < e * Abs(sum))
        break;
    sum += add;

} 

WriteLine($"sum = {sum}\nAdditions = {i}");