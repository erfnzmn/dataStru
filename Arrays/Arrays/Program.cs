using System.Collections;

internal class Program
{

    static int Insert(int[] array, int n, int x, int pos)
    {
        {
            for (int i = n - 1; i >= pos; i--)
                array[i + 1] = array[i];
            return array[pos] = x;
        }
    }
    static int Find(int[] array, int b, int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (array[i] == b)
            {
                return i;
            }
            else
                return -1;
        }
        return -2;
    }

    static int Delete(int[] array, int n, int x)
    {
        int pos = Find(array, n, x);

        if (pos == -1)
        {
            return -1;
        }
        else
            for (int i = pos; i < n - 1; i++)
                array[i] = array[i + 1];


        return n - 1;
    }

}