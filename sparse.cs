using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sparse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Sparse(int[,] S,int lenght,int count)
            {
                int[,] xalvat = new int[count + 1, 3];
                xalvat[0, 0] = lenght;
                xalvat[0, 1] = lenght;
                xalvat[0, 2] = count;
                int k = 1;
                for (int i = 0; i < lenght; i++)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        if (S[i, j] != 0)
                        {
                            xalvat[k, 0] = i;
                            xalvat[k, 1] = j;
                            xalvat[k, 2] = S[i, j];
                            k++;
                        }
                    }
                }
                return xalvat;
            }
        }
    }
}
