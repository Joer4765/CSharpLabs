using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_1;

public class Function : INotifyPropertyChanged
{
    private string arr;

    private static IEnumerable<int> TaskFunc(IReadOnlyList<int[]> inputArray)
    {
        var n = inputArray.Count;

        var result = new int[n];
        for (var i = 0; i < n; i++)
        {
            var total = 0;
            for (var j = 0; j < inputArray[i].Length; j++)
            {
                if (inputArray[i][j] >= 0) continue;
                total += inputArray[i][j];
            }
            result[i] = total;
        }
        return result;
    }
    

    public string Arr
    { 
        get => arr;
        set
        {
            var match = Regex.Match(value, @"[^\d\s\n-]");
            if (!match.Success) arr = value;
            OnPropertyChanged("Arr");
            OnPropertyChanged("Result");
            
        }
    }

    private string Machinations(string s)
    {
        var resInt = s.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Array
                .ConvertAll(x.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse)).ToArray();

            
        var res = TaskFunc(resInt);
        return string.Join(' ', res);
    }
    
    public string Result
    {
        get => Machinations(Arr);
        set => OnPropertyChanged("Result");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}