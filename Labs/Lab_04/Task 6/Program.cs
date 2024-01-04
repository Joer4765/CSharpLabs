// See https://aka.ms/new-console-template for more information

using static System.Console;


for (var i = 10; i > 0; i--)
{
    WriteLine();
    WriteLine(string.Join(
        Environment.NewLine,
        $"{i} green bottle{(i - 1 != 0 ? "s" : "")} hanging on the wall,",
        $"{i} green bottle{(i - 1 != 0 ? "s" : "")} hanging on the wall,",
        $"There'll be {i - 1} bottles hanging on the wall."
        ));
}
