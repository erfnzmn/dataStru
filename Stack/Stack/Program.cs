using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        class Stack
        {
            private int top;
            private int max;
            private int[] sta;
            public Stack(int size)
            {
                sta = new int[size];
                top = -1;
                max = size;
            }
            public void Push(int x)
            {
                if (Is_Full())
                    return;
                else
                    sta[++top] = x;
            }
            public int Pop()
            {
                if (Is_Empty())
                    return -1;
                else
                    return sta[top--];
            }
            public int Peek()
            {
                int top2 = top;
                if (Is_Empty())
                    return -1;
                else
                    return sta[top2];
            }
            public bool Is_Empty()
            {
                if (top == -1)
                    return true;
                else
                    return false;
            }
            public bool Is_Full()
            {
                if (top == max - 1)
                    return true;
                else
                    return false;
            }
            public void Print_Stack()
            {
                for (int i = 0; i <= top; i++)
                    Console.Write(sta[i] + " ");
            }

        }
    }
}
