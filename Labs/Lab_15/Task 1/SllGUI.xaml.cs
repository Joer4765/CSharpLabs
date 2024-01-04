using System;
using System.Collections.Generic;
using System.Windows;

namespace Task_1;

public partial class SllGUI
{
    private readonly SinglyLinkedList _linkedList = new();
    public SllGUI()
    {
        InitializeComponent();
    }
    
     private void UpdateOutput(string data)
    {
        OutputText.Text = data;
    }

    private void DisplayList_Click(object sender, RoutedEventArgs e)
    {
        UpdateOutput(_linkedList.ToString());
    }

    private void Size_Click(object sender, RoutedEventArgs e)
    {
        UpdateOutput(_linkedList.Count.ToString());
    }

    private void IsEmpty_Click(object sender, RoutedEventArgs e)
    {
        UpdateOutput(_linkedList.IsEmpty ? "List is empty" : "List is not empty");
    }

    private void InsertBeginning_Click(object sender, RoutedEventArgs e)
    {
        string data = DataEntry.Text;
        if (!string.IsNullOrWhiteSpace(data))
        {
            _linkedList.InsertAtBeginning(data);
            DataEntry.Clear();
            DisplayList_Click(null, null);
        }
    }

    private void InsertEnd_Click(object sender, RoutedEventArgs e)
    {
        string data = DataEntry.Text;
        if (!string.IsNullOrWhiteSpace(data))
        {
            _linkedList.InsertAtEnd(data);
            DataEntry.Clear();
            DisplayList_Click(null, null);
        }
    }

    private void InsertPos_Click(object sender, RoutedEventArgs e)
    {
        string data = DataEntry.Text;
        string posStr = PosEntry.Text;

        if (!string.IsNullOrWhiteSpace(data) && !string.IsNullOrWhiteSpace(posStr))
        {
            int pos;
            if (int.TryParse(posStr, out pos))
            {
                _linkedList.InsertAtPosition(data, pos);
                DataEntry.Clear();
                PosEntry.Clear();
                DisplayList_Click(null, null);
            }
        }
    }

    private void RemoveAll_Click(object sender, RoutedEventArgs e)
    {
        _linkedList.RemoveAll();
        DisplayList_Click(null, null);
    }

    private void RemoveAtIndex_Click(object sender, RoutedEventArgs e)
    {
        string data = Input1Entry.Text;
        if (!string.IsNullOrWhiteSpace(data))
        {
            int index;
            if (int.TryParse(data, out index))
            {
                _linkedList.RemoveAtIndex(index);
                Input1Entry.Clear();
                DisplayList_Click(null, null);
            }
        }
    }

    private void RemoveValue_Click(object sender, RoutedEventArgs e)
    {
        string data = Input1Entry.Text;
        if (!string.IsNullOrWhiteSpace(data))
        {
            _linkedList.RemoveValue(data, false);
            Input1Entry.Clear();
            DisplayList_Click(null, null);
        }
    }

    private void RemoveValues_Click(object sender, RoutedEventArgs e)
    {
        var data = Input1Entry.Text;
        if (string.IsNullOrWhiteSpace(data)) return;
        var values = new List<string>(data.Split());
        _linkedList.RemoveAllValues(values);
        Input1Entry.Clear();
        DisplayList_Click(null, null);
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        var oldData = Input1Entry.Text;
        var newData = Input2Entry.Text;
        if (string.IsNullOrWhiteSpace(oldData) || string.IsNullOrWhiteSpace(newData)) return;
        _linkedList.Edit(oldData, newData);
        Input1Entry.Clear();
        Input2Entry.Clear();
        DisplayList_Click(null, null);
    }

    private void ReplaceAll_Click(object sender, RoutedEventArgs e)
    {
        var oldData = Input1Entry.Text;
        var newData = Input2Entry.Text;
        if (string.IsNullOrWhiteSpace(oldData) || string.IsNullOrWhiteSpace(newData)) return;
        _linkedList.ReplaceAll(oldData, newData);
        Input1Entry.Clear();
        Input2Entry.Clear();
        DisplayList_Click(null, null);
    }

    private void Search_Click(object sender, RoutedEventArgs e)
    {
        var data = Input1Entry.Text;
        if (string.IsNullOrWhiteSpace(data) || !int.TryParse(data, out var index)) return;
        var result = _linkedList.Search(index);
        Input1Entry.Clear();
        UpdateOutput(string.Join(Environment.NewLine, result));
    }

    private void SortList_Click(object sender, RoutedEventArgs e)
    {
        _linkedList.Sort();
        DisplayList_Click(null, null);
    }

    private void SaveToFile_Click(object sender, RoutedEventArgs e)
    {
        _linkedList.SaveToFile("dll.txt");
        MessageBox.Show("Saved successfully");
    }

    private void LoadFromFile_Click(object sender, RoutedEventArgs e)
    {
        _linkedList.LoadFromFile("dll.txt");
        DisplayList_Click(null, null);
    }
}