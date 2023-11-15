internal class Program
{
    class Queue
    {
        private int front;
        private int rear;
        private int[] que;
        private int max;

        public Queue(int size)
        {
            que = new int[size];
            front = 0;
            rear = 0;
            max = size;
        }

        public void addq(int item)
        {
            if(front == (rear + 1) % max)
            {
                return;
            }
            rear = (rear + 1) % max;
            que[rear] = item;
        }
        public int Delete()
        {
            if (front == rear)
            {
                return -1;
            }
            else
            {
                front = (front + 1) % max;
                return que[front];
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
                return que[(front + 1) % max];
            }
        }
        public bool isFull()
        {
            if (front == (rear + 1) % max)
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
        public void printQueue()
        {
            for(int i=front+1;i<=rear;i++)
            {
                Console.Write(que[i] + " ");
            }
        }

    }
}