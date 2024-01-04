using static System.Console;

Write("Enter n: ");
var parse = int.TryParse(ReadLine(), out var n);
var matrix = new int[n][];
var rand = new Random();
for (var i = 0; i < n; i++)
{
    matrix[i] = new int[n];
    for (var j = 0; j < n; j++)
    {
        matrix[i][j] = rand.Next(-50, 50);
        Write($"{matrix[i][j],4}");
    }
    WriteLine();
    
}

var isUniques = false;
WriteLine("Indexes of rows with unique elements: ");

for (var i = 0; i < n; i++)
{
    if (matrix[i].Distinct().Count() == matrix[i].Length)
    {
        Write($"{i} ");
        isUniques = true;
    }
}

if (!isUniques)
{
    WriteLine("There is no rows with unique elements");
}

for (var i = 0; i < n; i++)
{
    var isUnique = true;
    for (var j = 0; j < n; j++)
    {
        
        for (var k = 0; k < j; k++)
        {
            if (matrix[i][j] == matrix[i][k])
            {
                isUnique = false;
                break;
            }
        }
        for (var k = j + 1; k < n; k++)
        {
            if (matrix[i][j] == matrix[i][k])
            {
                isUnique = false;
                break;
            }
        }
        if (!isUnique)
            break;
    }
    if (isUnique)
    {
        Write($"{i} ");
        isUniques = true;
    }
}
WriteLine();