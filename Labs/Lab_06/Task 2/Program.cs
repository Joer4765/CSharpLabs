using static System.Console;
using CommunityToolkit.HighPerformance;

Write("Enter n: ");
var nParse = int.TryParse(ReadLine(), out var n);
Write("Enter m: ");
var mParse = int.TryParse(ReadLine(), out var m);

var rand = new Random();

var matrix = new int[n, m];
for (var i = 0; i < n; i++)
{
    for (var j = 0; j < m; j++)
    {
        matrix[i, j] = rand.Next(-50, 50);
        Write($"{matrix[i, j], 4}");
    }
    WriteLine();
}

var span2D = new Span2D<int>(matrix);

var totals = new int[m];
for (var i = 0; i < m; i++)
    totals[i] = span2D.GetColumn(i).ToArray().Sum();

var totalsMin = totals.Min();
WriteLine($"Min sum: {totalsMin}");
WriteLine($"Index of col with min sum: {Array.IndexOf(totals, totalsMin)}");