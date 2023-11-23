using System;
using System.Collections;
using System.Runtime.Intrinsics.Arm;

internal class Program
{

    class Queue
    {
        private Stack<int> Q1stack=new Stack<int>();
        private Stack<int> Q2stack = new Stack<int>();
       
        public void addQueue(int item)
        {
            while(Q1stack.Count>0)
            {
                Q2stack.Push(Q1stack.Pop());
            }
            Q1stack.Push(item);
            while(Q2stack.Count>0)
            {
                Q1stack.Push(Q2stack.Pop());
            }
        }
        public int Delete()
        {
            if(Q1stack.Count==0)
            {
                return 0;
            }
            int item = (int)Q1stack.Peek();
            Q1stack.Pop();
            return item;
        }
    }

    //private static void Main(string[] args)
    //{
    //    Queue Q = new Queue();
    //    Q.addQueue(1);
    //    Q.addQueue(2);
    //    Q.addQueue(4);
    //    Q.addQueue(7);
    //    Q.addQueue(9);
       
    //    Console.ReadKey();
    //}
}