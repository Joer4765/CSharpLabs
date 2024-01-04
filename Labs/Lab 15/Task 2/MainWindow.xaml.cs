// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Windows;
//
// namespace Task_2;
//
// public partial class MainWindow
// {
//     private List<string>? _modifiedList;
//     private static readonly char[] Separator = { ' ' };
//
//     public MainWindow()
//     {
//         InitializeComponent();
//     }
//
//     private List<string> ReadListFromFile(string fileName)
//     {
//         try
//         {
//             var data = File.ReadAllText(fileName).Split(Separator, StringSplitOptions.RemoveEmptyEntries);
//             return new List<string>(data);
//         }
//         catch (IOException)
//         {
//             return new List<string>();
//         }
//     }
//
//     private List<string>? ReplaceList(List<string>? l1, IReadOnlyList<string> l2, IEnumerable<string> l3)
//     {
//         try
//         {
//             var index = l1!.IndexOf(l2[0]);
//             if (index >= 0)
//             {
//                 l1.RemoveRange(index, l2.Count);
//                 l1.InsertRange(index, l3);
//             }
//         }
//         catch (ArgumentException)
//         {
//         }
//         return l1;
//     }
//
//     private void ReadDataButton_Click(object sender, RoutedEventArgs e)
//     {
//         var l1 = ReadListFromFile("L1.txt");
//         var l2 = ReadListFromFile("L2.txt");
//         var l3 = ReadListFromFile("L3.txt");
//
//         _modifiedList = ReplaceList(new List<string>(l1), new List<string>(l2), new List<string>(l3));
//
//         L1DataLabel.Content = string.Join(" ", l1);
//         L2DataLabel.Content = string.Join(" ", l2);
//         L3DataLabel.Content = string.Join(" ", l3);
//     }
//
//     private void WriteDataButton_Click(object sender, RoutedEventArgs e)
//     {
//         if (_modifiedList == null) return;
//         using (var file = new StreamWriter("modified_L1.txt"))
//         {
//             for (var i = 0; i < _modifiedList.Count; i += 7)
//             {
//                 file.WriteLine(string.Join(" ", _modifiedList.GetRange(i, Math.Min(7, _modifiedList.Count - i))));
//             }
//         }
//
//         L1ModifiedDataLabel.Content = string.Join(" ", _modifiedList);
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Task_2;

public partial class MainWindow : Window
{
    private List<string> l1 = null;
    private List<string> l2 = null;
    private List<string> l3 = null;
    private List<string> modifiedList = null;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ReadDataButton_Click(object sender, RoutedEventArgs e)
    {
        l1 = ReadListFromFile("L1.txt");
        l2 = ReadListFromFile("L2.txt");
        l3 = ReadListFromFile("L3.txt");

        modifiedList = ReplaceList(l1, l2, l3);

        L1DataLabel.Content = string.Join(" ", l1);
        L2DataLabel.Content = string.Join(" ", l2);
        L3DataLabel.Content = string.Join(" ", l3);
    }

    private void WriteDataButton_Click(object sender, RoutedEventArgs e)
    {
        using (StreamWriter file = new StreamWriter("modified_L1.txt"))
        {
            for (var i = 0; i < modifiedList.Count; i += 7)
            {
                file.WriteLine(string.Join(" ", modifiedList.Skip(i).Take(7)));
            }
        }

        L1ModifiedDataLabel.Content = string.Join(" ", modifiedList);
    }

    private List<string> ReadListFromFile(string fileName)
    {
        // var s = 
        return File.ReadAllText(fileName).Replace("\r\n", " ").TrimEnd(' ').Split(' ').ToList();
    }

    private List<string> ReplaceList(List<string> l1, List<string> l2, List<string> l3)
    {
        var result = new List<string>(l1);
        var pos = Contains(l2, l1);

        if (pos == null) return result;
        result.RemoveRange(pos.Item1, pos.Item2 - pos.Item1);
        result.InsertRange(pos.Item1, l3);

        return result;
    }

    private Tuple<int, int> Contains(List<string> small, List<string> big)
    {
        for (var i = 0; i <= big.Count - small.Count; i++)
        {
            if (small.SequenceEqual(big.GetRange(i, small.Count)))
            {
                return Tuple.Create(i, i + small.Count);
            }
        }
        return null;
    }
}