using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QueueLL.LinkedList;
internal class Program
{
    class Queue
    {
    public int front;
    public int rear;
    Node queue = new Node(3);
    public void enqueue(int item)
    {
        if (front == rear)
        {
            return;
        }
        else
        {
            queue.InsertAtTheEnd(item);
        }
    }
    public void dequeue()
    {
        if (front == null)
        {
            return;
        }
        else
        {
            queue.DeleteFromBeginning();
        }
    }
        public void printlist()
        {
            queue.printList();
        }     
    }
}