using System.Windows;

namespace Task_3;

public class Node
{
    public readonly string Data; 
    public Node Next;

    public Node(string data)
    {
        Data = data;
    }
}

public class CircularLinkedList
{
    public Node Head { get; private set; }

    private void AddToEmpty(string data)
    {
        if (Head != null) return;

        var newNode = new Node(data);
        Head = newNode;
        Head.Next = Head;
    }

    public override string ToString()
    {
        if (Head == null)
            return "The list is empty";

        var result = "";
        var newNode = Head.Next;

        do
        {
            result += newNode.Data + " -> ";
            newNode = newNode.Next;
        }
        while (newNode != Head.Next);

        return result;
    }

    public void AddEnd(string data)
    {
        if (Head == null)
        {
            AddToEmpty(data);
            return;
        }

        var newNode = new Node(data)
        {
            Next = Head.Next
        };
        Head.Next = newNode;
        Head = newNode;
    }
    
    public void DeleteNode(string key) 
    { 
  
        // If linked list is empty 
        if (Head == null) 
            return; 
  
        // If the list contains only a 
        // single node 
        if (Head.Data == key && Head.Next == Head) { 
            Head = null; 
            return; 
        }

        var last = Head;
        Node d;
  
        // If head is to be deleted 
        if (Head.Data == key) { 
  
            // Find the last node of the list 
            while (last.Next != Head) 
                last = last.Next; 
  
            // Point last node to the next of 
            // head i.e. the second node 
            // of the list 
            last.Next = Head.Next; 
            Head = last.Next; 
            return; 
        } 
  
        // Either the node to be deleted is 
        // not found or the end of list 
        // is not reached 
        while (last.Next != Head && last.Next.Data != key) { 
            last = last.Next; 
        } 
  
        // If node to be deleted was found 
        if (last.Next.Data == key) { 
            d = last.Next; 
            last.Next = d.Next; 
        } 
        else
            MessageBox.Show("Given node is not found in the list!!"); 
    } 
}
