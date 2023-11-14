using System;
internal class Program
{
    class Queue
    {
        private int front;
        private int rear;
        private int max;
        private int[] que;

        public Queue(int size)
        {
            que = new int[size];
            front = -1;
            rear = -1;
            max = size;

        }

        public void enqueue(int item)
        {
            if (rear == max - 1)
            {
                isFull();
                Console.WriteLine("Queue is full");
                return;
            }
            else
                que[++rear] = item;
        }

        public int deleteQueue()
        {
            if (front == rear)
            {
                isEmpty();
                Console.WriteLine("Is Empty");
                return -1;
            }
            else
            {
                return que[++front];
            }
        }
        public int printQueue()
        {
            for(int i=front+1;i<=rear;i++)
            {
                    Console.Write(que[i] + " ");
                
            }
            return 1;
        }

        public bool isEmpty()
        {
            if (front == rear)
                return true;
            else
                return false;
        }
        public bool isFull()
        {
            if (rear == max - 1)
                return true;
            else
                return false;
        }
            //static void Main()
            //{
            //    Queue Q = new Queue(5);

            //    Q.enqueue(10);
            //Q.enqueue(20);
            //Q.enqueue(30);
            //Q.enqueue(40);
            //Q.enqueue(50);
            //Q.deleteQueue();
            //Q.deleteQueue();
            //Console.WriteLine(Q.isEmpty());
            //    Q.printQueue();
            //}
    }
}