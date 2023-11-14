using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] ArrayList = new int[10];
        ArrayList[0] = 2;
        ArrayList[1] = 9;
        ArrayList[2] = 0;
        ArrayList[3] = 15;
        ArrayList[4] = 5;
        int x = 12;
        int n = 5;
        int pos = 3;

        Console.Write("Before Insertion: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(ArrayList[i] + " ");
        }
        Console.WriteLine();
        Insert(ArrayList, n, x, pos);
        n += 1;
        Console.Write("After Insertion: ");
        for (int i = 0; i < n; i++)
            Console.Write(ArrayList[i] + " ");
        Console.ReadKey();
    }
    static int Insert(int[] arr, int n, int x, int pos)
    {
        {
            for (int i = n - 1; i >= pos; i--)
                arr[i + 1] = arr[i];
            return arr[pos] = x;
        }
    }

    static int Delete(int[] array, int n, int x)
    {
        int pos = Find(array, n, x);

        if (pos == -1)
        {
            Console.WriteLine("Element not found");
            return n;
        }

        else

            for (int i = pos; i < n - 1; i++)
                array[i] = array[i + 1];


        return n - 1;
    }

}