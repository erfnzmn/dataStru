using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProject
{
    class HashT
    {
        public Node[] Hash(int[] A)
        {
            Node[] Hashtable = new Node[10];
            for (int i = 0; i < 10; i++)
                Hashtable[i] = new Node(10);
            int[] Count = new int[10];
            for (int i = 0; i < A.Length; i++)
            {
                int place = A[i] % 10;

                Hashtable[place].InsertAtTheEnd(A[i]);
            }
            return Hashtable;
        }
        public void printHashT(Node[] A)
        {
            for (int i = 0; i < A.Length; i++)
                A[i].printList();
        }
    }
}
