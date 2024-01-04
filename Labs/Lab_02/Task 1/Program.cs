// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;


Write("Enter R: ");
int.TryParse(ReadLine(), out var r);
Write("Enter x: ");
int.TryParse(ReadLine(), out var x);


if (x < -r) 
{
    WriteLine($"y = {r}");
}
else if (x < r)
{
    // (x – a)^2 + (y – b)^2 = r^2, a = 0, b = r — circle formula
    // x^2 + (y - r)^2 = r^2
    // (y - r)^2 = r^2 - x^2
    // Abs(y - r) = Sqrt(r^2 - x^2)
    // y = r + Sqrt(r^2 - x^2)
    // y = r - Sqrt(r^2 - x^2) — we need this
    WriteLine($"y = {r - Sqrt(Pow(r, 2) - Pow(x, 2))}");
}
else if (x < 2 * r)
{
    // (x - x1) / (x2 - x1) = (y - y1 / y2 - y1) — formula of a line passing through two points
    // y - y1 =  (x - x1) * (y2 - y1) / (x2 - x1)
    // y = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
    int y1 = r, y2 = -r, x1 = r, x2 = 2 * r;
    WriteLine($"y = {y1 + (x - x1) * (y2 - y1) / (x2 - x1)}");
}
else
{
    // y = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
    int y1 = -r, y2 = 0, x1 = 2 * r, x2 = 3 * r;
    WriteLine($"y = {y1 + (x - x1) * (y2 - y1) / (x2 - x1)}");
}
