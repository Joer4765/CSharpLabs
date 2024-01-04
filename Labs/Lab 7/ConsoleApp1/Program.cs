using static System.Math;

var s = "-3 21 -1 22 20 6 -8 -23 -4 20 11 -19 -5 -9 -15 -2 -14 17 -17 -23 -21 11 -4 19 9 14 -9 -3 -10 -3 -3 8 " +
        "-15 -12 -5 -7 7 -25 -24 19 21 -8 -24 12 22 -3 -16 2 -2 21";


var arr = new[] { 4, 1, 2, 0, 2, 5};
// arr = Array.ConvertAll(s.Split(" "), int.Parse);
Console.WriteLine(arr.Length);
Console.WriteLine(string.Join(" ", arr));

static void Merge(int[] arr, int l, int r)
{
    var max = Max(l, r);
    while (l != r)
    {
        if (arr[l] > arr[r])
        {
            (arr[l], arr[r]) = (arr[r], arr[l]);
            (arr[l + 1], arr[r]) = (arr[r], arr[l + 1]);
        }
        
        l += 1;
        r = Min(r + 1, 2 * max - 1);
    }
}

static void Divide(int[] arr, int l, int r)
{
    if (l >= r)
        return;
    
    if (r - l > 2)
    {
        Divide(arr, l, r / 2);
        Divide(arr, (r + l + 1) / 2, r);
        Merge(arr, l, (r + 1) / 2);
    }

    if (arr[r] < arr[l])
    {
        (arr[r], arr[l]) = (arr[l], arr[r]);
    }
}
Divide(arr, 0, arr.Length - 1);

Console.WriteLine(string.Join(" ", arr));


