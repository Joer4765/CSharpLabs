using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1;


public class Node
{
    public string Data;
    public Node Next;

    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList
{
    private Node head;
    private int size;

    public SinglyLinkedList()
    {
        head = null;
        size = 0;
    }

    // Display elements of the list
    public override string ToString()
    {
        string s = "";
        Node current = head;
        while (current != null)
        {
            s += current.Data + " -> ";
            current = current.Next;
        }
        return s;
    }

    // Get the number of elements in the list
    public int Count
    {
        get { return size; }
    }

    public bool IsEmpty
    {
        get { return size == 0; }
    }

    // Insert elements into the list
    public void InsertAtBeginning(string data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
        size++;
    }

    public void InsertAtEnd(string data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        size++;
    }

    public void InsertAtPosition(string data, int position)
    {
        if (position < 0)
            position = 0;
        if (position > size)
            position = size;

        Node newNode = new Node(data);

        if (position == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        size++;
    }

    // Remove elements from the list
    public void RemoveAll()
    {
        head = null;
        size = 0;
    }

    public void RemoveAtIndex(int index)
    {
        if (index < 0 || index >= size) return;
        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            var current = head;
            for (var i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        size--;
    }

    public void RemoveValue(string value, bool mul)
    {
        var current = head;
        while (current != null && current.Data == value)
        {
            head = current.Next;
            current = head;
            size--;
            if (!mul)
                return;
        }
        while (current != null)
        {
            if (current.Next != null && current.Next.Data == value)
            {
                current.Next = current.Next.Next;
                size--;
                if (!mul)
                    return;
            }
            current = current.Next;
        }
    }
    

    public void RemoveAllValues(IEnumerable<string> values)
    {
        foreach (var value in values)
        {
            RemoveValue(value, true);
        }
    }

    // Edit elements in the list
    public void Edit(string oldValue, string newValue)
    {
        var current = head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
                return;
            }
            current = current.Next;
        }
    }

    // Replace all instances of a value with a new value
    public void ReplaceAll(string oldValue, string newValue)
    {
        var current = head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    // Search for an element by a given index
    public string Search(int index)
    {
        var current = head;
        for (var i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    // Sort the list (assuming elements are comparable)
    public void Sort()
    {
        if (head == null)
        {
            return;
        }

        var values = new string[size];
        Node current = head;
        var i = 0;
        while (current != null)
        {
            values[i] = current.Data;
            current = current.Next;
            i++;
        }

        Array.Sort(values);

        current = head;
        i = 0;
        while (current != null)
        {
            current.Data = values[i];
            current = current.Next;
            i++;
        }
    }

    // Save the list to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            Node current = head;
            while (current != null)
            {
                writer.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    // Load the list from a file
    public void LoadFromFile(string filename)
    {
        RemoveAll();
        var lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            InsertAtEnd(line);
        }
    }
}