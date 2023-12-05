using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    class Program
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

            public void InsertIndex(Node pnode, int ndata)
            {
                if (pnode == null)
                {
                    return;
                }
                Node newnode = new Node(ndata);
                newnode.link = pnode.link;
                pnode.link = newnode;
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
            public void DeleteWithPosition(int position)
            {
                if (head == null)
                {
                    return;
                }
                Node temp = head;
                if (position == 0)
                {
                    head = temp.link;
                    return;
                }
                for (int i = 0; i != null && i < position - 1; i++)

                    temp = temp.link;
                if (temp == null || temp.link == null)
                {
                    return;
                }
                Node next = temp.link.link;
                temp.link = next;
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
            public int Length()
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

        public static void Main(String[] args)
        {

            Node list = new Node(5);

            list.InsertAtTheBeginning(7);
            list.InsertAtTheBeginning(1);
            list.InsertAtTheBeginning(3);
            list.InsertAtTheBeginning(2);
            list.InsertAtTheBeginning(8);
            list.Reverse();
            list.printList();
            Console.ReadKey();
        }

    }
}
