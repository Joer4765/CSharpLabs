// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Math;

int Factorial(int n)
{
    if (n == 0)
        return 1;
    return n * Factorial(n - 1);
}

double b(int n)
{
    if (n == 1)
        return 1;
    return Pow(a(n - 1), 2) + Pow(b(n - 1), 2);
}

double a(int n)
{
    if (n == 1)
        return 1;
    return 0.3 * b(n - 1) + 0.2 * a(n - 1);
}

double Sum(int n)
{
    if (n == 1)
        return 0.5;
    return a(n) * b(n) / Factorial(n + 1) + Sum(n - 1);
}


WriteLine("Enter n: ");
int.TryParse(ReadLine(), out var n);
WriteLine(Sum(n));