using System;
using System.Linq;

namespace P06
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseFunc = num => nums.Reverse().ToArray();
            Func<int[], int[]> removeFunc = num => nums.Where(x => x % n != 0).ToArray();
            Action<int[]> printNums = numbers => Console.WriteLine(string.Join(" ", numbers));

            nums = reverseFunc(nums);
            nums = removeFunc(nums);
            printNums(nums);            
        }
    }
}
