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
        public int printQueue()
        {
            for (int i = front + 1; i <= rear; i++)
            {
                Console.Write(que[i] + " ");

            }
            return 1;
        }

        public void addQueue(int item)
        {
            if (rear == max - 1)
            {
                isFull();
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
                return -1;
            }
            else
            {
                return que[++front];
            }
        }
        public int Peek()
        {
            int front2 = front;
            if (isEmpty())
            {
                return -1;
            }
            else
            {
                return que[++front2];
                front2--;
            }
        }

        public bool isFull()
        {
            if (rear == max - 1)
                return true;
            else
                return false;
        }
        public bool isEmpty()
        {
            if (front == rear)
                return true;
            else
                return false;
        }
    }
}