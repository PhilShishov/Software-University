using System;
using System.Collections.Generic;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                names.Add(line);
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
