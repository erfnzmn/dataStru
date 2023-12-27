using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
   
public enum COLOR { RED, BLACK };

public class Node
{
    public int data;
    public COLOR color;
    public Node LChild;
    public Node RChild;
    public Node Parent;
    public Node(int val)
    {
        this.data = val;
        LChild = RChild = Parent = null;
        color = COLOR.RED;
    }
    public Node Uncle()
    {
        if (Parent == null && Parent.Parent == null)
        {
            return null;
        }
        if (Parent.Left())
        {
            return Parent.Parent.RChild;
        }
        else
        {
            return Parent.Parent.LChild;
        }
    }
    public Node Sibling()
    {
        if (Parent == null)
        {
            return null;
        }
        if (Left())
        {
            return Parent.RChild;
        }
        else
        {
            return Parent.LChild;
        }
    }
    public void MoveDown(Node nParent)
    {
        if (Parent != null)
        {
            if (Left())
            {
                Parent.LChild = nParent;
            }
            else
            {
                Parent.RChild = nParent;
            }
            nParent.Parent = Parent;
            Parent = nParent;
        }
    }
    public bool RedChild()
    {
        return (LChild != null && LChild.color == COLOR.RED) || (RChild != null && RChild.color == COLOR.RED);
    }
    public bool Left()
    {
        return this==Parent.LChild;
    }
}
public class RedBlackTree
{
    public Node root;
    public Node RotateLeft(Node node)
    {
        Node x = node.RChild;
        Node y = x.LChild;
        x.LChild = node;
        node.RChild = y;
        node.Parent = x;

        if (y != null)
            y.Parent = node;

        return x;
    }
    public Node RotateRight(Node node)
    {
        Node x = node.LChild;
        Node y = x.RChild;
        x.RChild = node;
        node.LChild = y;
        node.Parent = x;

        if (y != null)
            y.Parent = node;

        return x;
    }
    public Node Replace(Node x)
    {
        if (x.LChild == null && x.RChild == null)
        {
            return null;
        }
        if (x.LChild != null && x.RChild != null)
        {
            return Successor(x.RChild);
        }
        if (x.LChild != null)
            return x.LChild;
        else
            return x.RChild;
    }
    public void Insert(int n)
    {
        Node newNode = new Node(n);
        if (root == null)
        {
            newNode.color = COLOR.BLACK;
            root = newNode;
        }
        else
        {
            Node temp = Search(n);

            if (temp.data == n)
            {
                return;
            }
            else
            {
                newNode.Parent = temp;
            }
            if (n < temp.data)
                temp.LChild = newNode;
            else
                temp.RChild = newNode;

            FixRedRed(newNode);
        }
    }
    public void Remove(Node v)
    {
        Node u = Replace(v);

        bool uvBlack = ((u == null || u.color == COLOR.BLACK) && (v.color == COLOR.BLACK));
        Node parent = v.Parent;

        if (u == null)
        {
            if (v == root)
            {
                root = null;
            }
            else
            {
                if (uvBlack)
                {
                    FixDoubleBlack(v);
                }
                else
                {
                    if (v.Sibling() != null)
                        v.Sibling().color = COLOR.RED;
                }
                if (v.Left())
                {
                    parent.LChild = null;
                }
                else
                {
                    parent.RChild = null;
                }
            }
            return;
        }

        if (v.LChild == null || v.RChild == null)
        {
            if (v == root)
            {
                v.data = u.data;
                v.LChild = v.RChild = null;
                Remove(u);
            }
            else
            {
                if (v.Left())
                {
                    parent.LChild = u;
                }
                else
                {
                    parent.RChild = u;
                }
                u.Parent = parent;

                if (uvBlack)
                {
                    FixDoubleBlack(u);
                }
                else
                {
                    u.color = COLOR.BLACK;
                }
            }
            return;
        }
        SwapValues(u, v);
        Remove(u);
    }
    public void DeleteByVal(int n)
    {
        if (root == null)
            return;

        Node v = Search(n);

        if (v.data != n)
        {
            return;
        }
        Remove(v);
    }
    void FixRedRed(Node x)
    {
        if (x == root)
        {
            x.color = COLOR.BLACK;
            return;
        }
        Node parent = x.Parent, grandparent = parent.Parent,
             uncle = x.Uncle();

        if (parent.color != COLOR.BLACK)
        {
            if (uncle != null && uncle.color == COLOR.RED)
            {
                parent.color = COLOR.BLACK;
                uncle.color = COLOR.BLACK;
                grandparent.color = COLOR.RED;
                FixRedRed(grandparent);
            }
            else
            {
                if (parent.Left())
                {
                    if (x.Left())
                    {
                        SwapColors(parent, grandparent);
                    }
                    else
                    {
                        RotateLeft(parent);
                        SwapColors(x, grandparent);
                    }
                    RotateRight(grandparent);
                }
                else
                {
                    if (x.Left())
                    {
                        RotateRight(parent);
                        SwapColors(x, grandparent);
                    }
                    else
                    {
                        SwapColors(parent, grandparent);
                    }
                    RotateLeft(grandparent);
                }
            }
        }
    }
    void FixDoubleBlack(Node x)
    {
        if (x == root)
            return;

        Node sibling = x.Sibling(), parent = x.Parent;

        if (sibling == null)
        {
            FixDoubleBlack(parent);
        }
        else
        {
            if (sibling.color == COLOR.RED)
            {
                parent.color = COLOR.RED;
                sibling.color = COLOR.BLACK;
                if (sibling.Left())
                {
                    RotateRight(parent);
                }
                else
                {
                    RotateLeft(parent);
                }
                FixDoubleBlack(x);
            }
            else
            {
                if (sibling.RedChild())
                {
                    if (sibling.LChild != null && sibling.LChild.color == COLOR.RED)
                    {
                        if (sibling.Left())
                        {
                            sibling.LChild.color = sibling.color;
                            sibling.color = parent.color;
                            RotateRight(parent);
                        }
                        else
                        {
                            sibling.LChild.color = parent.color;
                            RotateRight(sibling);
                            RotateLeft(parent);
                        }
                    }
                    else
                    {
                        if (sibling.Left())
                        {
                            sibling.RChild.color = parent.color;
                            RotateLeft(sibling);
                            RotateRight(parent);
                        }
                        else
                        {
                            sibling.RChild.color = sibling.color;
                            sibling.color = parent.color;
                            RotateLeft(parent);
                        }
                    }
                    parent.color = COLOR.BLACK;
                }
                else
                {
                    sibling.color = COLOR.RED;
                    if (parent.color == COLOR.BLACK)
                        FixDoubleBlack(parent);
                    else
                        parent.color = COLOR.BLACK;
                }
            }
        }
    }
    void Inorder(Node x)
    {
        if (x == null)
            return;
        Inorder(x.LChild);
        Console.WriteLine(x.data + " ");
        Inorder(x.RChild);
    }
    public Node Successor(Node x)
    {
        Node temp = x;
        while (temp.LChild != null)
            temp = temp.LChild;
        return temp;
    }

    public void SwapValues(Node x, Node y)
    {
        int temp = x.data;
        x.data = y.data;
        y.data = temp;
    }
    public void SwapColors(Node x, Node y)
    {
        COLOR temp = x.color;
        x.color = y.color;
        y.color = temp;
    }
    Node Search(int x)
    {
        Node temp = root;
        while (temp != null)
        {
            if (x < temp.data)
            {
                if (temp.LChild == null)
                    break;
                else
                    temp = temp.LChild;
            }
            else if (x == temp.data)
            {
                break;
            }
            else
            {
                if (temp.RChild == null)
                    break;
                else
                    temp = temp.RChild;
            }
        }
        return temp;
    }
    public void PrintInOrder()
    {
        if (root == null)
            Console.WriteLine("Tree is empty");
        else
            Inorder(root);
        Console.WriteLine();
    }
}