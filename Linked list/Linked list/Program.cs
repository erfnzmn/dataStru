using System;
internal class Program
{
    
    public class Node
    {
        public int data;
        public Node next;
        Node head;
        public Node(int d)
        {
            data = d;
            next = null;
        }

        public void InsertAtTheEnd(int ndata)
        {
                Node newnode = new Node(ndata);
                newnode.next = head;
                head = newnode;
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
                head = temp.next;
                return;
            }
            for (int i = 0; i != null && i < position - 1; i++)

                temp = temp.next;
            if (temp == null || temp.next == null)
            {
                return;
            }
            Node next = temp.next.next;
            temp.next = next;
        }
      
        public void printList()
        {
            Node node = head;
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
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
