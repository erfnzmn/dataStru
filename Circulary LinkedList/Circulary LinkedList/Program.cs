internal class Program
{
    class Node
    {
        public Node link;
        public int data;
        public Node head;
        public Node(int ndata)
        {
            data = ndata;
            link = null;
        }
        public Node Lastnode(Node head)
        {
            Node last = head;
            while (last.link != head)
                last = last.link;
            return last;
        }
        public void InsertAtTheBeginning(int newdata)
        {
            Node newNode = new Node(newdata);
            newNode.link = null;
            if (head == null)
            {
                head = newNode;
                newNode.link = head;
            }
            else
            {
                Node temp = head;
                while (temp.link != head)
                    temp = temp.link;
                temp.link = newNode;
                newNode.link = head;
                head = newNode;
            }
        }
        public void InsertWithIndex(int newdata,int index)
        {
            Node newnode = new Node(newdata);
            newnode.link = null;
            Node temp = head;
            if (index < 1)
            {
                return;
            }
            else if (index == 1)
            {
                if (head == null)
                {
                    head = newnode;
                    head.link = head;
                }
                else
                {
                    while (temp.link != head)
                    {
                        temp = temp.link;
                    }
                    newnode.link = head;
                    head = newnode;
                    temp.link = head;
                }
            }
            else
            {
                temp = head;
                for (int i = 1; i < index - 1; i++)
                    temp = temp.link;
                newnode.link = temp.link;
                temp.link = newnode;
            }
        }
        public void InsertAtTheEnd(int ndata)
        {
            Node newnode = new Node(ndata);
            if (head == null)
            {
                head = newnode;
                newnode.link = head;
            }
            Node last = Lastnode(head);
            last.link = newnode;
            newnode.link = head;
        }
        public void RemoveNodeAtBeginning()
        {
            Node last = Lastnode(head);
            head = head.link;
            last.link = head;
        }
        public void RemoveWithIndex(int index)
        {
            Node NodeToDelete = head;
            Node temp = head;
            int count = 0;

            if (temp != null)
            {
                count++;
                temp = temp.link;
            }
            while (temp != head)
            {
                count++;
                temp = temp.link;
            }
            if(index<1||index>count)
            {
                return;
            }
            else if (index == 1)
            {
                if (head.link == head)
                {
                    head = null;
                }
                else
                {
                    while (temp.link != head)
                        temp = temp.link;
                    head = head.link;
                    temp.link = head;
                    NodeToDelete = null;
                }
            }
            else
            {
                temp = head;
                for (int i = 1; i < index - 1; i++)
                    temp = temp.link;
                NodeToDelete = temp.link;
                temp.link = temp.link.link ;
                NodeToDelete = null;
            }
        }
        public void RemoveNodeAtEnd()
        {
            Node last = head;
            Node prev = null;
            while (last.link != head)
            {
                prev = last;
                last = last.link;
            }
            prev.link = head;
        }
        public void Update(int position, int ndata)
        {
            Node temp = head;
            for (int i = 1; i < position; i++)
            {
                temp = temp.link;
            }
            temp.data = ndata;
        }
        public void Reverse()
        {
            if (head == null)
            {
                return;
            }
            Node prev = null;
            Node current = head;
            do
            {
                link = current.link;
                current.link = prev;
                prev = current;
                current = link;
            } while (current != head);
            head.link = prev;
            head = prev;
        }
        public int Size()
        {
            Node temp = head;
            int count = 0;
            if (head != null)
            {
                do
                {
                    temp = temp.link;
                    count++;
                } while (temp != head);
            }

            return count;
        }
        public void printlist()
        {
            Node node = head;
            if (node !=null)
            {
                while (true)
                {
                    Console.WriteLine(node.data + " ");
                    node = node.link;
                    if (node == head)
                        break;
                }
            }
        }
    }
    private static void Main(string[] args)
    {
        Node list = new Node(3);
        list.InsertAtTheBeginning(4);
        list.InsertAtTheBeginning(3);
        list.InsertAtTheBeginning(0);
        list.InsertWithIndex(100, 2);
        //list.RemoveWithIndex(3);
       
        //list.Reverse();
        list.printlist();

        Console.WriteLine();
        Console.WriteLine(list.Size());
       
        Console.ReadKey();
    }
}
