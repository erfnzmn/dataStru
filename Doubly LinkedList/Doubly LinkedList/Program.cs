using System.Net.NetworkInformation;

internal class Program
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
        public void InsertWithIndex(int ndata,int index)
        {
            Node newnode = new Node(ndata);
            newnode.link = null;
            newnode.prev = null;

            if(index<0)
            {
                return;
            }
            else if(index==0)
            {
                newnode.link = head;
                head.prev = newnode;
                head = newnode;
            }
            else
            {
                Node temp = new Node(ndata);
                temp = head;
                for(int i=0;i<index-1;i++)
                {
                    if(temp!=null)
                    {
                        temp = temp.link;
                    }
                }
                if(temp!=null)
                {
                    newnode.link = temp.link;
                    newnode.prev = temp;
                    temp.link = newnode;
                    if(newnode.link!=null)
                    {
                        newnode.link.prev = newnode;
                    }
                }
            }
        }
        public int Size()
        {
            Node temp = head;
            int count = 0;
            while(temp!=null)
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
    private static void Main(string[] args)
    {
        Node head = null;
        Node list = new Node(10);
        list.InsertAtTheBeginning(2);
        list.InsertAtTheBeginning(4);
        list.InsertAtTheBeginning(3);
        list.InsertWithIndex(12, 2);
        //Console.WriteLine(list.Size());
        list.printList();
    }
}