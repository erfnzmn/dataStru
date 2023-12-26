using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {6,2,5,4,3,7};
            Sorts N = new Sorts();
            N.BucketSort(arr);
            N.printArray(arr);
            Console.ReadKey();
        }
    }
}
