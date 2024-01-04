using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Math;

namespace Task_3;

public class Searching : INotifyPropertyChanged
{

    public int[] arr;
    public int[] arrSorted;
    public int[] a;
    public int[] b;
    public int search;
    
    public string Arr => string.Join(' ', arr);
    public string Search => search.ToString();
    public string A => string.Join(' ', a);
    public string B => string.Join(' ', b);

    public string ArrSorted
    {
        get
        {
            if (arrSorted?.Any() != true)
            {
                arrSorted = (int[])arr.Clone();
                Array.Sort(arrSorted);
            }
            return string.Join(' ', arrSorted);
        }

    } 
    
    public string LinearSearch
    {
        get
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == search)
                {
                    return i.ToString();
                }
            }
            return "-1";
        }
        set => OnPropertyChanged("LinearSearch");
    }

    public string BinarySearch
    {
        
        get
        {
            // var binarySearch = (int[])arr.Clone();
            // Array.Sort(binarySearch);
            int l = 0, r = arrSorted.Length - 1;
            while (l <= r) 
            {
                var m = l + (r - l) / 2;
 
                // Check if x is present at mid
                if (arrSorted[m] == search)
                    return m.ToString();
 
                // If x greater, ignore left half
                if (arrSorted[m] < search)
                    l = m + 1;
 
                // If x is smaller, ignore right half
                else
                    r = m - 1;
            }

            return "-1";
        }
        set => OnPropertyChanged("BinarySearch");
    }
    
    public string LongestCommonSubstring
    {
        
        get
        {
            static int lcs(int[] x, int[] y, int m, int n)
            {
                if (m == 0 || n == 0)
                    return 0;
                if (x[m - 1] == y[n - 1])
                    return 1 + lcs(x, y, m - 1, n - 1);
                else
                    return Max(lcs(x, y, m, n - 1), 
                        lcs(x, y, m - 1, n));
            }

            return lcs(a, b, a.Length, b.Length).ToString();
        }
        set => OnPropertyChanged("LongestCommonSubstring");
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}