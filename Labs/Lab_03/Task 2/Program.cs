// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

double GetVectorAngle(double coordX1, double coordY1, double coordX2, double coordY2)
{
    return Acos((coordX1 * coordX2 + coordY1 * coordY2) / 
                (Sqrt(Abs(coordX1 * coordX1 + coordY1 * coordY1)) * 
                 Sqrt(Abs(coordX2 * coordX2 + coordY2 * coordY2)))) * 180 / PI;
}


Write("Enter x1: ");
double.TryParse(ReadLine(), out var x1);
Write("Enter y1: ");
double.TryParse(ReadLine(), out var y1);
Write("Enter x2: ");
double.TryParse(ReadLine(), out var x2);
Write("Enter y2: ");
double.TryParse(ReadLine(), out var y2);
Write("Enter x3: ");
double.TryParse(ReadLine(), out var x3);
Write("Enter y3: ");
double.TryParse(ReadLine(), out var y3);

var angle1 = GetVectorAngle(x2-x1, y2-y1, x3-x1, y3-y1);
var angle2 = GetVectorAngle(x3-x2, y3-y2, x1-x2, y1-y2);
var angle3 = GetVectorAngle(x2-x3, y2-y3, x1-x3, y1-y3);
var angleMax = Max(angle3, Max(angle1, angle2));

WriteLine($"Max angle = {angleMax}");

switch (angleMax)
{
    case > 90:
        WriteLine("Obtuse");
        break;
    case < 90:
        WriteLine("Acute");
        break;
    default:
        WriteLine("Right");
        break;
}