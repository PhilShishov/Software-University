namespace P01
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(nums, 0));
        }

        private static int Sum(int[] nums, int index)
        {
            if (index == nums.Length)
            {
                return 0;
            }

            return nums[index] + Sum(nums, index + 1);
        }
    }
}
