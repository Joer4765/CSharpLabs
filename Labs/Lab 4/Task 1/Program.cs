See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

double TriangleSquare(double diagonal)
{
    return Pow(diagonal, 2) / 2;
}

double TrianglePerimeter(double diagonal)
{
    return 2 * diagonal * Sqrt(2);
}

Write("Enter diagonal: ");
double.TryParse(ReadLine(), out var d);
WriteLine($"Square = {TriangleSquare(d)}");
WriteLine($"Perimeter = {TrianglePerimeter(d)}");

