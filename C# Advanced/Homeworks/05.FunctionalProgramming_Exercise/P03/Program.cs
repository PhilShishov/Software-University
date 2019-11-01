
namespace P03
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minNum = n => nums.Min();

            Console.WriteLine(minNum(nums));
        }
    }
}
