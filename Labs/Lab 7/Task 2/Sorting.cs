using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Math;

namespace Task_2;

public class Sorting : INotifyPropertyChanged
{

    public int[] arr;

    public string Arr => string.Join(' ', arr);

    public string BubbleSort
    {
        get
        {
            var bubbleSort = (int[])arr.Clone();
            var sorted = false;
            while(!sorted)
            {
                sorted = true;
                for (var j = 0; j < bubbleSort.Length - 1; j++)
                {
                    if (bubbleSort[j] <= bubbleSort[j + 1]) continue;
                    (bubbleSort[j], bubbleSort[j + 1]) = (bubbleSort[j + 1], bubbleSort[j]);
                    sorted = false;
                }
            }
            return string.Join(' ', bubbleSort);
        }
        set => OnPropertyChanged("BubbleSort");

    }
    
    public string ShakerSort
    {
        get
        {
            var shakerSort = (int[])arr.Clone();
            var sorted = false;
            var shaker = 0;
            while (!sorted)
            {
                sorted = true;
                for (var i = shaker; i < shakerSort.Length - shaker - 1; i++)
                {
                    if (shakerSort[i] <= shakerSort[i + 1]) continue;
                    (shakerSort[i], shakerSort[i + 1]) = (shakerSort[i + 1], shakerSort[i]);
                    sorted = false;
                }
                for (var i = shakerSort.Length - shaker - 1; i > shaker; i--)
                {
                    if (shakerSort[i] >= shakerSort[i - 1]) continue;
                    (shakerSort[i], shakerSort[i - 1]) = (shakerSort[i - 1], shakerSort[i]);
                    sorted = false;
                }
                ++shaker;
            }

            return string.Join(' ', shakerSort);
        }
        set => OnPropertyChanged("ShakerSort");
    }
    
    public string InsertionSort
    {
        get
        {
            var insertionSort = (int[])arr.Clone();
            
            for (var i = 1; i < insertionSort.Length; i++)
            {
                for (var j = i; j > 0 && insertionSort[j] < insertionSort[j - 1]; j--)
                {
                    (insertionSort[j], insertionSort[j - 1]) = (insertionSort[j - 1], insertionSort[j]);
                }
            }
            return string.Join(' ', insertionSort);
        }
        set => OnPropertyChanged("InsertionSort");
    }
    
    public string StoogeSort
    {
        get
        {
            var stoogeSort = (int[])arr.Clone();

            static void Func(int[] arr, int l, int h)
            {
                if (l >= h)
                    return;
    
                if (arr[l] > arr[h]) 
                {
                    (arr[l], arr[h]) = (arr[h], arr[l]);
                }
    
                if (h - l + 1 > 2) 
                {
                    var t = (h - l + 1) / 3;
        
                    Func(arr, l, h - t);
                    Func(arr, l + t, h);
                    Func(arr, l, h - t);
                }
            }
            Func(stoogeSort, 0, stoogeSort.Length - 1);
            
            return string.Join(' ', stoogeSort);
        }
        set => OnPropertyChanged("StoogeSort");
    }
    
    public string ShellSort
    {
        get
        {
            var shellSort = (int[])arr.Clone();
            var n = shellSort.Length;
            
            for (var gap = n/2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < n; i++)
                {
                    for (var j = i; j >= gap && shellSort[j] < shellSort[j - 1]; j--)
                    {
                        (shellSort[j], shellSort[j - 1]) = (shellSort[j - 1], shellSort[j]);
                    }
                }
            }
            return string.Join(' ', shellSort);
        }
        set => OnPropertyChanged("ShellSort");
    }
    
    public string MergeSort
    {
        get
        {
            var mergeSort = (int[])arr.Clone();

            // Merges two subarrays of []arr.
            // First subarray is arr[l..m]
            // Second subarray is arr[m+1..r]
            void Merge(int[] arr, int l, int m, int r)
            {
                // Find sizes of two
                // subarrays to be merged
                int n1 = m - l + 1;
                int n2 = r - m;
         
                // Create temp arrays
                var L = new int[n1];
                var R = new int[n2];
                int i, j;
         
                // Copy data to temp arrays
                for (i = 0; i < n1; ++i)
                    L[i] = arr[l + i];
                for (j = 0; j < n2; ++j)
                    R[j] = arr[m + 1 + j];
         
                // Merge the temp arrays
         
                // Initial indexes of first
                // and second subarrays
                i = 0;
                j = 0;
         
                // Initial index of merged
                // subarray array
                int k = l;
                while (i < n1 && j < n2) {
                    if (L[i] <= R[j]) {
                        arr[k] = L[i];
                        i++;
                    }
                    else {
                        arr[k] = R[j];
                        j++;
                    }
                    k++;
                }
         
                // Copy remaining elements
                // of L[] if any
                while (i < n1) {
                    arr[k] = L[i];
                    i++;
                    k++;
                }
         
                // Copy remaining elements
                // of R[] if any
                while (j < n2) {
                    arr[k] = R[j];
                    j++;
                    k++;
                }
            }
            
            void Sort(int[] arr, int l, int r)
            {
                if (l < r) {
                    // Find the middle
                    // point
                    var m = (r + l) / 2;
         
                    // Sort first and
                    // second halves
                    Sort(arr, l, m);
                    Sort(arr, m + 1, r);
         
                    // Merge the sorted halves
                    Merge(arr, l, m, r);
                }
            }
            
            Sort(mergeSort, 0, mergeSort.Length - 1);
            
            return string.Join(' ', mergeSort);
        }
        set => OnPropertyChanged("ShellSort");
    }
    
    public string SelectionSort
    {
        get
        {
            var selectionSort = (int[])arr.Clone();
            
            static void Sort(int[] arr)
            {
                var n = arr.Length;
 
                // One by one move boundary of unsorted subarray
                for (var i = 0; i < n - 1; i++)
                {
                    // Find the minimum element in unsorted array
                    var minIdx = i;
                    for (var j = i + 1; j < n; j++)
                        if (arr[j] < arr[minIdx])
                            minIdx = j;
 
                    // Swap the found minimum element with the first
                    // element
                    (arr[minIdx], arr[i]) = (arr[i], arr[minIdx]);
                }
            }
            Sort(selectionSort);
            
            return string.Join(' ', selectionSort);
        }
        set => OnPropertyChanged("SelectionSort");
    }
    
    public string QuickSort
    {
        get
        {
            var quickSort = (int[])arr.Clone();
            
            static int Partition(int[] arr, int low, int high)
            {
                // Choosing the pivot
                var pivot = arr[high];
 
                // Index of smaller element and indicates
                // the right position of pivot found so far
                var i = low - 1;
 
                for (var j = low; j <= high - 1; j++) {
 
                    // If current element is smaller than the pivot
                    if (arr[j] < pivot) {
 
                        // Increment index of smaller element
                        i++;
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
                (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
                return i + 1;
            }
 
            // The main function that implements QuickSort
            // arr[] --> Array to be sorted,
            // low --> Starting index,
            // high --> Ending index
            static void Sort(int[] arr, int low, int high)
            {
                if (low < high) {
 
                    // pi is partitioning index, arr[p]
                    // is now at right place
                    var pi = Partition(arr, low, high);
 
                    // Separately sort elements before
                    // and after partition index
                    Sort(arr, low, pi - 1);
                    Sort(arr, pi + 1, high);
                }
            }
            
            Sort(quickSort, 0, quickSort.Length - 1);
            
            return string.Join(' ', quickSort);
        }
        set => OnPropertyChanged("ShellSort");
    }
    


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}