using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrayLL.Linkedlist;

namespace ArrayLL
{
    class Program
    {
        class Array
        {
            public int size;
            Node A = new Node(5);
            public Array(int Size)
            {
                size = Size;
                for (int i = 0; i < size; i++)
                {
                    A.InsertAtTheEnd(i);
                }

            }
            public void Insert(int data, int index)
            {
                A.InsertIndex(data, index);
            }
            public void Delete(int index)
            {
                A.DeleteWithPosition(index);
            }
            public void print()
            {
                A.printList();
            }
        }
    }
}
