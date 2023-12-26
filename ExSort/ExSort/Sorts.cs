using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSort
{
    class Sorts
    {
        public class Node
        {
            public int data;
            public Node link;
            Node head;
            public Node(int x)
            {
                data = x;
                link = null;
            }
            public int Size()
            {
                Node temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.link;
                }
                return count;
            }
            public void InsertAtTheEnd(int ndata)
            {
                Node newnode = new Node(ndata);
                if (head == null)
                {
                    head = new Node(ndata);
                    return;
                }
                newnode.link = null;

                Node last = head;
                while (last.link != null)
                    last = last.link;

                last.link = newnode;
                return;
            }
            public void printList()
            {
                Node node = head;
                while (node != null)
                {
                    Console.Write(node.data + " ");
                    node = node.link;
                }
            }
            
        }
        
        public void BubbleSort(int[] A)
        {
            int n = A.Length;
            int temp;
            for (int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            }
        }
        public void SelectedSort(int[] A)
        {
            int n = A.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (A[j] < A[min_idx])
                        min_idx = j;
                int temp = A[min_idx];
                A[min_idx] = A[i];
                A[i] = temp;
            }
        }
        public void InsertedSort(int[] A)
        {
            int n = A.Length;
            for (int i = 1; i < n; i++)
            {
                int key = A[i];
                int j = i - 1;
                while ( j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = key;
            }
        }
        public void MergeSort(int[] A)
        {
            if (A.Length < 2)
                return;
            int Middle = A.Length / 2;
            int[] left= new int[Middle];
            int[] right= new int[A.Length-Middle];
            for (int i = 0; i < Middle; i++)
                left[i] = A[i];
            for (int i = Middle; i < A.Length; i++)
                right[i - Middle] = A[i];
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, A);
            void Merge(int[] Left,int[] Right, int[] Natijeh){
                int L = 0;
                int R = 0;
                int N = 0;
                while (L<Left.Length && R < Right.Length)
                {
                    if (Left[L] <= Right[R])
                    {
                        Natijeh[N++] = Left[L++];
                    }
                    else
                    {
                        Natijeh[N++] = Right[R++];
                    }
                }
                while(L<Left.Length)
                    Natijeh[N++] = Left[L++];
                while (R < Right.Length)
                    Natijeh[N++] = Right[R++];
            }
        }
        public void QuickSort(int[] A,int start,int end)
        {
            if (start >= end)
                return;
            int pivot = A[end];
            int b = start-1;
            for (int i = start; i <= end; i++)
            {
                if (A[i] <= pivot)
                {
                    int temp;
                    temp = A[++b];
                    A[b] = A[i];
                    A[i] = temp;
                }
            }
            QuickSort(A, start, b - 1);
            QuickSort(A, b + 1, end);
        }
        public void CountingSort(int[] A)
        {
            int n = A.Length;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i] > max)
                    max = A[i];
            }
            int[] B = new int[max+1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i] == j)
                        B[j]++;
                }
            }
            int k = 0;
            for (int i = 0; i < B.Length; i++)
                for (int j = 0; j < B[i]; j++)
                    A[k++] = i;
        }
        public void BucketSort(int[] A)
        {
            void SortLinkedList(LinkedList<int> list)
            {
                List<int> tempList = new List<int>(list);
                tempList.Sort();
                list.Clear();
                foreach (var item in tempList)
                {
                    list.AddLast(item);
                }
            }
            int NBuckets = A.Length / 2;
            LinkedList<int>[] Buckets = new LinkedList<int>[NBuckets];
            for (int i = 0; i < A.Length; i++)
            {
                Buckets[A[i] / NBuckets] = new LinkedList<int>();
            }
            for (int i = 0; i < A.Length; i++)
            {
                Buckets[A[i] / NBuckets].AddLast(A[i]);
            }
            for (int i = 0; i < NBuckets; i++)
            {
                SortLinkedList(Buckets[i]);
            }
            int k = 0;
            for (int i = 0; i < Buckets.Length; i++)
            {
                if (Buckets[i] != null)
                {
                    LinkedListNode<int> node = Buckets[i].First;
                    while (node != null)
                    {
                        A[k] = node.Value;
                        node = node.Next;
                        k++;
                    }
                }
            }
        }
        public void printArray(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        
    }
}
