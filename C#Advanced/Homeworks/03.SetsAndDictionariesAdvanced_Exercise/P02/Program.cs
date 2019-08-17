using System;
using System.Collections.Generic;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = nums[0];
            int m = nums[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setTwo.Add(num);
            }

            setOne.IntersectWith(setTwo);

            Console.WriteLine(string.Join(" ", setOne));
        }
    }
}
