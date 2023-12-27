
using System.ComponentModel.Design.Serialization;
using System.Xml;

public class Node
    {
        public int data;
        public Node Child;
        public Node next;
    public Node(int v)
    {
        this.data = v;
        Child = null;
    }
}
public class Tree
{
    public Node root;
    public Node Insert(Node parent, int data)
    {
        if (root == null)
        {
            root = new Node(data);
        }
        parent.Child = new Node(data)
        {
            next = parent.Child
        };
        return parent.Child;
    }
 
    private static void Main(string[] args)
    {
        Tree t = new Tree();
        t.root = new Node(6);
        t.Insert(t.root, 5);
        t.Insert(t.root,8);
        t.Insert(t.root, 21);
        //t.Insert(t.root.next, 9);
        Node x = t.Search(t.root,5);
    }
}