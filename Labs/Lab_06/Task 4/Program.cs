// See https://aka.ms/new-console-template for more information

using static System.Console;

Write("Enter n: ");
var nParse = int.TryParse(ReadLine(), out var n);
var matrix = new int[n][];
var arr = new int[n];

WriteLine("Enter matrix: ");
for (var i = 0; i < n; i++)
{
    matrix[i] = Array.ConvertAll(ReadLine()?.Split()!, int.Parse);
    var length = matrix[i].Length - 1;
    arr[i] = matrix[i][length - length % 2];
    
}

WriteLine("Last even index elements: ");
foreach (var e in arr)
{
    Write($"{e} ");
}

