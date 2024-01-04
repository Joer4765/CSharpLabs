using System.Collections.Generic;
using System.Windows;

namespace Task_3;

internal class Node
{
    public int Key;
    public string Str;
    public Node Left;
    public Node Right;

    public Node(int key, string str)
    {
        Str = str;
        Key = key;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public Node root;
    

    public void Insert(int key, string str)
    {
        root = Insert(root, key, str);
    }

    private static Node Insert(Node root, int key, string str)
    {
        if (root == null)
        {
            return new Node(key, str);
        }
        if (key < root.Key)
        {
            root.Left = Insert(root.Left, key, str);
        }
        else
        {
            root.Right = Insert(root.Right, key, str);
        }
        return root;
    }

    public void Delete(int key)
    {
        root = Delete(root, key);
    }

    private Node Delete(Node root, int key)
    {
        if (root == null)
        {
            MessageBox.Show("Element is not in the tree.", "Error");
            return null;
        }
        if (key < root.Key)
        {
            root.Left = Delete(root.Left, key);
        }
        else if (key > root.Key)
        {
            root.Right = Delete(root.Right, key);
        }
        else
        {
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            root.Key = MinValueNode(root.Right).Key;
            root.Right = Delete(root.Right, root.Key);
        }
        return root;
    }

    private Node MinValueNode(Node node)
    {
        var current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }

    public Dictionary<int, string> InorderTraversal()
    {
        // var result = new List<int>();
        var result = new Dictionary<int, string>();
        InorderTraversal(root, result);
        // return result.ToArray();
        return result;
    }

    private void InorderTraversal(Node root, IDictionary<int, string> result)
    {
        if (root == null) return;
        InorderTraversal(root.Left, result);
        result.Add(root.Key, root.Str);
        InorderTraversal(root.Right, result);
    }

    public Node Search(int key)
    {
        return Search(root, key);
    }

    private Node Search(Node root, int key)
    {
        if (root == null)
        {
            return null;
        }
        if (root.Key == key)
        {
            return root;
        }
        if (key < root.Key)
        {
            return Search(root.Left, key);
        }
        return Search(root.Right, key);
    }
}
