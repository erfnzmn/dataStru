using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProject
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
