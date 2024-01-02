using System;
using System.Reflection;
using System;

class MaxHeap
{
    class Node
    {
        public int data;
        public Node LChild;
        public Node RChild;

        public Node(int value)
        {
            this.data = value;
            LChild = null;
            RChild = null;
        }
    }
    Node root;

    public MaxHeap()
    {
        root = null;
    }
    public void Insert(int value)
    {
        root = Insert(root, value);
    }
    private Node Insert(Node node, int value)
    {
        if (node == null)
        {
            node = new Node(value);
            return node;
        }

        if (value > node.data)
            node.LChild = Insert(node.LChild, value);
        else
            node.RChild = Insert(node.RChild, value);

        return node;
    }
    public void Delete(int value)
    {
        root = Delete(root, value);
    }
    private Node Delete(Node root,int value)
    {
        if (root == null)
            return root;

        if (value > root.data)
            root.LChild = Delete(root.LChild, value);
        else if (value < root.data)
            root.RChild = Delete(root.RChild, value);
        else
        {
            if (root.LChild == null)
                return root.RChild;
            else if (root.RChild == null)
                return root.LChild;

            root.data = MaxValue(root.LChild);

            root.LChild = Delete(root.LChild, root.data);
        }
        return root;
    }
    private int MaxValue(Node node)
    {
        int maxValue = node.data;
        while (node.RChild != null)
        {
            maxValue = node.RChild.data;
            node = node.RChild;
        }
        return maxValue;
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
        if (root != null)
        {
            inorder(root.LChild);
            Console.Write(root.data + " ");
            inorder(root.RChild);
        }
    }
}