using static System.Console;

Write("Enter count of stores: ");
var nParse = int.TryParse(ReadLine(), out var n);
const int m = 12;

var rand = new Random();

var matrix = new int[n, m];
for (var i = 0; i < n; i++)
{
    Write($"{i}:");
    for (var j = 0; j < m; j++)
    {
        matrix[i, j] = rand.Next(0, 100);
        Write($"{matrix[i, j], 4}");
    }
    WriteLine();
}

Write("Choose a store: ");
var storeParse = int.TryParse(ReadLine(), out var store);
Write("Choose a quarter: ");
var quarterParse = int.TryParse(ReadLine(), out var quarter);

var incomes = Enumerable.Range(3 * (quarter - 1), 3)
    .Select(x => matrix[store, x])
    .ToArray();
Write($"The incomes of the {store} store in the {quarter} quarter: ");
foreach (var income in incomes)
    Write($"{income} ");

WriteLine($"\nThe total income of the {store} store for the {quarter} quarter: {incomes.Sum()}");