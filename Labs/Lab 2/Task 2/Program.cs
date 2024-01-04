// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter R: ");
int.TryParse(ReadLine(), out var r);
Write("Enter x: ");
int.TryParse(ReadLine(), out var x);
Write("Enter y: ");
int.TryParse(ReadLine(), out var y);

if (x < 0)
{
    // (x – a)^2 + (y – b)^2 = r^2, a = 0, b = r — circle formula
    int a = -r, b = r;
    double dot = Pow(x - a, 2) + Pow(y - b, 2), circle = Pow(r, 2);
    
    if (dot < circle)
        WriteLine("Yes");
    else if (dot > circle)
        WriteLine("No");
    else
        WriteLine("On the edge");
}

else if (x > 0)
{
    if (x < 2 * r && -r < y && y < 0)
        WriteLine("Yes");
    else if (x > 2 * r || y > 0 || y < -r)
        WriteLine("No");
    else
        WriteLine("On the edge");
}

else
{
    if (y >= -r && y <= 0 || y == r)
        WriteLine("On the edge");
    else
        WriteLine("No");
}