using System;
using System.ComponentModel.Design.Serialization;

class MinHeap
{
    class Node
    {
        public int data;
        public Node LChild;
        public Node RChild;
        public Node(int value)
        {
            this.data = value;
            LChild = RChild = null;
        }
    }
    Node root = new Node(0);
    public void Insert(int value)
    {
        root = Insert(root, value);
    }
    private Node Insert(Node root, int value)
    {
        if (root == null)
        {
            return new Node(value);
        }

        if (value < root.data)
            root.LChild = Insert(root.LChild, value);
        else
            root.RChild = Insert(root.RChild, value);

        return root;
    }

    private int MinValue(Node root)
    {
        int minValue = root.data;
        while (root.LChild != null)
        {
            minValue = root.LChild.data;
            root = root.LChild;
        }
        return minValue;
    }
  
    public void DeleteMin()
    {
        root = DeleteMin(root);
    }

    private Node DeleteMin(Node root)
    {
        if (root == null)
            return root;

        if (root.LChild == null)
            return root.RChild;

        if (root.LChild.data < root.RChild.data)
        {
            root.data = root.LChild.data;
            root.LChild = DeleteMin(root.LChild);
        }
        else
        {
            root.data = root.RChild.data;
            root.RChild = DeleteMin(root.RChild);
        }

        return root;
    }

    public void PrintHeap()
    {
        if (root == null)
        {
            Console.WriteLine("Heap is empty");
            return;
        }

        Console.WriteLine("Printing Heap:");
        inorder(root);
    }
    private void inorder(Node root)
    {
        if (root == null)
        {
            return;
        }
        inorder(root.LChild);
        Console.Write(root.data + " ");
        inorder(root.RChild);
    }
    public static void Main(String[] args)
    {
        MinHeap m = new MinHeap();
        m.Insert(m.root, 5);
        m.Insert(m.root, 2);
        m.Insert(m.root, 4);
        m.Insert(m.root, 9);
        m.Insert(m.root, 12);
        m.PrintHeap();
        Console.ReadKey();
    }
    }