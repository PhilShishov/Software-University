using System;
using System.Linq;

namespace P07
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int key = int.Parse(Console.ReadLine());

            int index = BinarySearch.IndexOf(arr, key);
            Console.WriteLine(index);
        }

        //public static int IndexOf(int[] arr, int key)
        //{
        //    int lo = 0;
        //    int hi = arr.Length - 1;

        //    while (lo <= hi)
        //    {
        //        int mid = lo + (hi - lo) / 2;

        //        if (key < arr[mid])
        //        {
        //            hi = mid - 1;
        //        }
        //        else if (key > arr[mid])
        //        {
        //            lo = mid + 1;
        //        }
        //        else
        //        {
        //            return mid;
        //        }
        //    }

        //    return -1;
        //}
    }
}
