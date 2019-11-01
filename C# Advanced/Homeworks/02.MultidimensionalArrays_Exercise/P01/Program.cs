using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            //int dim = int.Parse(Console.ReadLine());

            //int leftDiagonal = 0;
            //int rightDiagonal = 0;

            //for (int row = 0; row < dim; row++)
            //{
            //    int[] numbers = Console.ReadLine()
            //    .Split(" ")
            //    .Select(int.Parse)
            //    .ToArray();

            //    for (int col = 0; col < dim; col++)
            //    {
            //        if (row == col)
            //        {
            //            rightDiagonal += numbers[col];
            //        }

            //        if (row + col == dim - 1)
            //        {
            //            leftDiagonal += numbers[col];
            //        }
            //    }
            //}

            //Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal));

            //Console.WriteLine(IsPalindrome("Deleveled"))

            string[] names1 = new string[] { "Emma", "Olivia", "Emma" };
            string[] names2 = new string[] { "Emma", "Olivia", "Emma" };
            Console.WriteLine(string.Join(", ", UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia

        }

        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            List<string> names = new List<string>(names1);

            foreach (var name in names)
            {
                if (names.Any(n => n == name))
                {
                    names.Remove(name);
                }
            }

            foreach (var name in names2)
            {
                if (!names1.Contains(name))
                {
                    names.Add(name);
                }
            }

            return names.ToArray();
        }


        //    public static bool IsPalindrome(string word)
        //    {
        //        if (word.Length <= 1)
        //            return true;

        //        char[] wordArr = word.ToLower().ToCharArray();
        //        int end = wordArr.Length - 1;
        //        int mid = wordArr.Length / 2;

        //        for (int i = 0; i < mid; i++)
        //        {
        //            if (wordArr[i] != wordArr[end - i])
        //                return false;
        //        }

        //        return true;
        //    }
    }
}
