using System;
internal class Program
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
        public int Length(Node head)
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

        list.InsertAtTheEnd(7);
        list.InsertAtTheEnd(1);
        list.InsertAtTheEnd(3);
        list.InsertAtTheEnd(2);
        list.InsertAtTheEnd(8);
       
        list.printList();
        //list.DeleteWithPosition(4);
        //list.DeleteEnd();

    }
}
