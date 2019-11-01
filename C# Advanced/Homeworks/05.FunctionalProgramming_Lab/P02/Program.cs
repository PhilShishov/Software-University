using System;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<string, int> parser = n => int.Parse(n);

            var nums = Console.ReadLine()
                .Split(", ")
                .Select(Parser)
                .ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }

        public static Func<string, int> Parser = n => int.Parse(n);
    }
}
