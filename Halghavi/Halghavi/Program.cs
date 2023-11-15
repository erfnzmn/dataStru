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
            front = -1;
            rear = -1;
            max = size;
        }

        public void addq(int item)
        {
            if(front == (rear + 1) % max)
            {
                isFull();
                return;
            }
            rear = (rear + 1) % max;
            que[rear] = item;
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

        public int Delete()
        {
            if (front == rear)
            {
                isEmpty();
                return -1;
            }
            else
            {
                front = (front + 1) % max;
                return que[front];
            }
        }
        public void printQueue()
        {
            for(int i=front+1;i<=rear;i++)
            {
                Console.Write(que[i] + " ");
            }
        }

    }
    static void Main()
    {
        Queue Q = new Queue(5);

        Q.addq(10);
        Q.addq(20);
        Q.addq(30);
        Q.addq(40);
        Q.addq(50);
        Q.Delete();
        Q.Delete();
        //Console.WriteLine(Q.isEmpty());
        Q.printQueue();
    }
}