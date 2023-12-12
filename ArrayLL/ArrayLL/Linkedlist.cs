using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLL
{
    class Linkedlist
    {
        public class Node
        {
            public int data;
            public Node link;
            Node head;
            public Node(int x)
            {
                data = x;
                link = null;
            }

            public void InsertAtTheBeginning(int ndata)
            {
                Node newnode = new Node(ndata);
                newnode.link = head;
                head = newnode;
            }

            public void InsertIndex(int newdata, int index)
            {
                Node newnode = new Node(newdata);
                newnode.link = null;
                if (index < 0)
                {
                    return;
                }
                else if (index == 0)
                {
                    newnode.link = head;
                    head = newnode;
                }
                else
                {
                    Node temp = new Node(newdata);
                    temp = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        if (temp != null)
                        {
                            temp = temp.link;
                        }
                    }
                    if (temp != null)
                    {
                        newnode.link = temp.link;
                        temp.link = newnode;
                    }
                }
            }
            public void InsertAtTheEnd(int ndata)
            {
                Node newnode = new Node(ndata);
                if (head == null)
                {
                    head = new Node(ndata);
                    return;
                }
                newnode.link = null;

                Node last = head;
                while (last.link != null)
                    last = last.link;

                last.link = newnode;
                return;
            }
            public void DeleteFromBeginning()
            {
                head = head.link;
            }
            public void DeleteWithPosition(int index)
            {
                if (head == null)
                {
                    return;
                }
                Node prev = head;
                if (index == 0)
                {
                    head = prev.link;
                    return;
                }
                for (int i = 0; i != null && i < index - 1; i++)

                    prev = prev.link;
                if (prev == null || prev.link == null)
                {
                    return;
                }
                Node next = prev.link.link;
                prev.link = next;
            }
            public void DeleteFromEnd()
            {
                Node last = head;
                Node prev = null;
                while (last.link != null)
                {
                    prev = last;
                    last = last.link;
                }
                prev.link = null;
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
            public void Reverse()
            {
                Node pnode = null;
                Node current = head;
                Node next = null;
                while (current != null)
                {
                    next = current.link;
                    current.link = pnode;
                    pnode = current;
                    current = next;
                }
                head = pnode;
            }
            public void Update(int ndata, int index)
            {
                Node temp = head;
                //if (index == 0)
                //{
                //    head.data = ndata;
                //    return;
                //}
                for (int i = 1; i < index; i++)
                {
                    temp = temp.link;
                }
                temp.data = ndata;
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

    }
}
