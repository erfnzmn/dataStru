using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        class Node
        {
            public int data;
            public Node link;
            public Node head;
            public Node prev;
            public Node(int x)
            {
                data = x;
            }

            public void InsertAtTheBeginning(int ndata)
            {
                Node newnode = new Node(ndata);
                newnode.link = null;
                newnode.prev = null;
                if (head == null)
                {
                    head = newnode;
                }
                else
                {
                    head.prev = newnode;
                    newnode.link = head;
                    head = newnode;
                }
            }
            public void InsertWithIndex(int ndata, int index)
            {
                Node newnode = new Node(ndata);
                newnode.link = null;
                newnode.prev = null;

                if (index < 1)
                {
                    return;
                }
                else if (index == 1)
                {
                    newnode.link = head;
                    head.prev = newnode;
                    head = newnode;
                }
                else
                {
                    Node temp = new Node(ndata);
                    temp = head;
                    for (int i = 1; i < index - 1; i++)
                    {
                        if (temp != null)
                        {
                            temp = temp.link;
                        }
                    }
                    if (temp != null)
                    {
                        newnode.link = temp.link;
                        newnode.prev = temp;
                        temp.link = newnode;
                        if (newnode.link != null)
                        {
                            newnode.link.prev = newnode;
                        }
                    }
                }
            }
            public void InsertAtTheEnd(int ndata)
            {
                Node new_node = new Node(ndata);
                new_node.link = null;
                Node last = head;
                if (head == null)
                {
                    new_node.prev = null;
                    head = new_node;
                    return;
                }
                while (last.link != null)
                    last = last.link;
                last.link = new_node;
                new_node.prev = last;
            }
            public void Update(int ndata, int index)
            {
                Node temp = head;
                for (int i = 0; temp != null && i < index; i++)
                {
                    temp = temp.link;
                }
                if (temp == null)
                    return;
                temp.data = ndata;
            }
            public void RemovefromBeginning()
            {
                if (head == null)
                {
                    return;
                }
                head = head.link;
                head.prev = null;
            }
            public void RemovefromEnd()
            {
                Node temp = head;
                while (temp.link.link != null)
                    temp = temp.link;
                temp.link = null;
            }
            public void RemoveWithIndex(int index)
            {
                if (index < 1)
                {
                    return;
                }
                else if (index == 1 && head != null)
                {
                    Node nodeToDelete = head;
                    head = head.link;
                    nodeToDelete = null;
                    if (head != null)
                        head.prev = null;
                }
                else
                {
                    Node temp = head;
                    for (int i = 1; i < index - 1; i++)
                    {
                        if (temp != null)
                        {
                            temp = temp.link;
                        }
                    }
                    if (temp != null && temp.link != null)
                    {
                        Node nodeToDelete = temp.link;
                        temp.link = temp.link.link;
                        if (temp.link.link != null)
                            temp.link.link.prev = temp.link;
                        nodeToDelete = null;
                    }
                }
            }
            public int Size()
            {
                Node temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.link;
                }
                return count;
            }

            public void printList()
            {
                Node node = head;
                while (node != null)
                {
                    Console.Write(node.data + " ");
                    node = node.link;
                }
            }
        }

        static void Main(string[] args)
        {
            Node list = new Node(5);
            list.InsertAtTheEnd(1);
            list.InsertAtTheEnd(2);
            list.InsertAtTheEnd(3);
            list.InsertAtTheEnd(4);
            //list.Update(20, 1);
            list.RemoveWithIndex(2);
            list.printList();
            Console.ReadKey();
        }
    }
}
