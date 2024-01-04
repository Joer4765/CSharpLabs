// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

int GetCoordinate()
{
    int.TryParse(ReadLine(), out var v);
    // if (v is >= 1 and <= 8) return v;
    if (v is < 1 or > 8)
    {
        Environment.Exit(0);
        WriteLine("You entered wrong coordinate");
    }
    return v;
}

WriteLine("White Bishop 1: ");
Write($"{"Row: ", 7}");
var wb1X = GetCoordinate();
Write($"{"Col: ", 7}");
var wb1Y = GetCoordinate();

WriteLine("White Bishop 2: ");
Write($"{"Row: ", 7}");
var wb2X = GetCoordinate();
Write($"{"Col: ", 7}");
var wb2Y = GetCoordinate();

WriteLine("Black Bishop 1: ");
Write($"{"Row: ", 7}");
var bb1X = GetCoordinate();
Write($"{"Col: ", 7}");
var bb1Y = GetCoordinate();

WriteLine("Black Bishop 2: ");
Write($"{"Row: ", 7}");
var bb2X = GetCoordinate();
Write($"{"Col: ", 7}");
var bb2Y = GetCoordinate();

// White Bishops
if (Abs(wb1X - wb2X) == Abs(wb1Y - wb2Y))
    WriteLine("White Bishops are defending each other");


// Black Bishops
if (Abs(bb1X - bb2X) == Abs(bb1Y - bb2Y))
    WriteLine("Black Bishops are defending each other");

// White Bishop 1 and Black Bishop 1
if (Abs(wb1X - bb1X) == Abs(wb1Y - bb1Y))
    WriteLine("White Bishop 1 and Black Bishop 1 are attacking each other");


// White Bishop 1 and Black Bishop 2
if (Abs(wb1X - bb2X) == Abs(wb1Y - bb2Y))
    WriteLine("White Bishop 1 and Black Bishop 2 are attacking each other");


// White Bishop 2 and Black Bishop 1
if (Abs(wb2X - bb1X) == Abs(wb2Y - bb1Y))
    WriteLine("White Bishop 2 and Black Bishop 1 are attacking each other");


// White Bishop 2 and Black Bishop 2
if (Abs(wb2X - bb2X) == Abs(wb2Y - bb2Y))
    WriteLine("White Bishop 2 and Black Bishop 2 are attacking each other");
