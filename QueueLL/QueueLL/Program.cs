using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QueueLL.LinkedList;
internal class Program
{
    class Queue
    {
    public Node front;
    public Node rear;
    public void enqueue(int item)
    {
        if (front == rear)
        {
            return;
        }
        else
        {
            rear.InsertAtTheEnd(item);
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
            front.DeleteFromBeginning();
        }
    }
        public void printlist()
        {
            printlist();
        }
        
}
    private static void Main(string[] args)
    {
        Queue myque = new Queue();
        myque.enqueue(1);
        myque.enqueue(8);
        myque.enqueue(34);
        myque.printlist();

    }
}