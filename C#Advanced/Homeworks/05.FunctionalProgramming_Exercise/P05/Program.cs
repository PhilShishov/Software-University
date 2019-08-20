using System;
using System.Linq;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            Func<int[], int[]> addFunc = num => nums.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiplyFunc = num => nums.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtractFunc = num => nums.Select(n => n - 1).ToArray();
            //Func<int[], int[]> printFunc = num => nums.Select(n => n - 2).ToArray();
            Action<int[]> printFunc = numbers
                => Console.WriteLine(string.Join(" ", numbers));

            while (input != "end")
            {
                if (input == "add")
                {
                    nums = addFunc(nums);
                }

                else if (input == "multiply")
                {
                    nums = multiplyFunc(nums);
                }

                else if (input == "subtract")
                {
                    nums = subtractFunc(nums);
                }

                else if (input == "print")
                {
                    printFunc(nums);
                }

                input = Console.ReadLine();
            }
        }
    }
}
