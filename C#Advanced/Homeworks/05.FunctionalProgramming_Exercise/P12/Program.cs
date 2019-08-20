using System;
using System.Collections.Generic;
using System.Linq;

namespace P12
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string result = names.FirstOrDefault(n => n.ToCharArray().Select(c => (int)c).Sum() >= length);

            Console.WriteLine(result);
        }
    }
}
