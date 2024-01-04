using System;
using System.IO;
using System.Collections.Generic;

namespace Task_1;

class NodeDLL
{
    public string Data { get; set; }
    public NodeDLL Prev { get; set; }
    public NodeDLL Next { get; set; }

    public NodeDLL(string data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}

class DoublyLinkedList
{
    private NodeDLL head;
    private NodeDLL tail;
    private int size;

    public int Count => size;

    public bool IsEmpty => head == null;

    public void InsertAtBeginning(string data)
    {
        NodeDLL newNodeDLL = new NodeDLL(data);
        if (head == null)
        {
            head = tail = newNodeDLL;
        }
        else
        {
            newNodeDLL.Next = head;
            head.Prev = newNodeDLL;
            head = newNodeDLL;
        }
        size++;
    }

    public void InsertAtEnd(string data)
    {
        NodeDLL newNodeDLL = new NodeDLL(data);
        if (tail == null)
        {
            head = tail = newNodeDLL;
        }
        else
        {
            newNodeDLL.Prev = tail;
            tail.Next = newNodeDLL;
            tail = newNodeDLL;
        }
        size++;
    }

    public void InsertAtPosition(string data, int position)
    {
        if (position < 0)
            position = 0;
        if (position > size)
            position = size;

        NodeDLL newNodeDLL = new NodeDLL(data);

        if (position == 0)
            InsertAtBeginning(data);
        else if (position == size)
            InsertAtEnd(data);
        else
        {
            NodeDLL current = head;
            for (int i = 0; i < position; i++)
                current = current.Next;

            newNodeDLL.Prev = current.Prev;
            newNodeDLL.Next = current;
            current.Prev.Next = newNodeDLL;
            current.Prev = newNodeDLL;
        }
        size++;
    }

    public void RemoveAll()
    {
        head = tail = null;
        size = 0;
    }

    public void RemoveAtIndex(int index)
    {
        if (index >= 0 && index < size)
        {
            NodeDLL current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                tail = current.Prev;

            size--;
        }
    }

    public void RemoveValue(string value)
    {
        NodeDLL current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;

                size--;
            }
            current = current.Next;
        }
    }

    public void RemoveValues(List<string> values)
    {
        foreach (string value in values)
        {
            RemoveValue(value);
        }
    }

    public void Edit(string oldValue, string newValue)
    {
        NodeDLL current = head;
        while (current != null)
        {
            if (current.Data == oldValue)
                current.Data = newValue;
            current = current.Next;
        }
    }

    public void ReplaceAll(string oldValue, string newValue)
    {
        NodeDLL current = head;
        while (current != null)
        {
            if (current.Data == oldValue)
                current.Data = newValue;
            current = current.Next;
        }
    }

    public string Search(int index)
    {
        var current = head;
        for (var i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public void Sort()
    {
        if (head == null)
            return;

        List<string> values = new List<string>();
        NodeDLL current = head;
        while (current != null)
        {
            values.Add(current.Data);
            current = current.Next;
        }

        values.Sort();

        current = head;
        foreach (string value in values)
        {
            current.Data = value;
            current = current.Next;
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            NodeDLL current = head;
            while (current != null)
            {
                writer.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        RemoveAll();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                InsertAtEnd(line);
            }
        }
    }

    public override string ToString()
    {
        var result = "";
        var current = head;
        while (current != null)
        {
            result += current.Data + " <-> ";
            current = current.Next;
        }
        return result;
    }
}