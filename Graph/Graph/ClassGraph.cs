using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class ClassGraph
    {
        public int _V;
        public LinkedList<int>[] adj;
        public ClassGraph(int V)
        {
            _V = V;
            adj = new LinkedList<int>[V];
            for (int i = 0; i < adj.Length; i++)
                adj[i] = new LinkedList<int>();
        }
        public static void RemoveAt(int[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                arr[a] = arr[a + 1];
            }
            // finally, let's decrement Array's size by one
            Array.Resize(ref arr, arr.Length - 1);
        }
        public void Addnode(int start, int data)
        {
            adj[start].AddLast(data);
        }
        public void AddEdge(int start, int end)
        {
            adj[start].AddLast(end);
        }
        public void RemoveVertex(int vertex)
        {
            for (int i = 0; i < _V; i++)
            {
                adj[i].Remove(adj[i].Find(vertex));
            }
            return;
        }

        public void RemoveEdge(int start, int end)
        {
            var temp = adj[start].Find(end);
            if (temp == null)
                return;
            adj[start].Remove(end);
        }
        public void DFS(int s)
        {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;
            Stack<int> S = new Stack<int>();
            visited[s] = true;
            S.Push(s);
            while (S.Any())
            {
                s = S.First();
                Console.Write(s + " ");
                S.Pop();
                LinkedList<int> list = adj[s];
                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        S.Push(val);
                    }
                }
            }
        }
        public void BFS(int s)
        {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;
            Queue<int> Q = new Queue<int>();
            visited[s] = true;
            Q.Enqueue(s);
            while (Q.Any())
            {
                s = Q.First();
                Console.Write(s + " ");
                Q.Dequeue();
                LinkedList<int> list = adj[s];
                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        Q.Enqueue(val);
                    }
                }
            }
        }
    }
}
