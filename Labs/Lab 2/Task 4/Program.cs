// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

Write("Enter x: ");
int.TryParse(ReadLine(), out var x);
Write("Enter y: ");
int.TryParse(ReadLine(), out var y);
Write("Enter z: ");
int.TryParse(ReadLine(), out var z);
Write("Enter k: ");
int.TryParse(ReadLine(), out var k);

switch (k)
{
    case 1:
        WriteLine(Min(Max(x, y), z));
        break;
    case >= 5 and <= 10:
        WriteLine(Min(Max(y, z), x));
        break;
    case >= 15 and <= 20:
        WriteLine(Min(Max(z, x), y));
        break;
    default:
        WriteLine(x + y + z);
        break;
}