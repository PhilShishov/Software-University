
namespace P05_WordFilter
{
    using System;
    using System.Linq;

    class WordFilter
    {
        static void Main()
        {
            //string[] words = Console.ReadLine()
            //    .Split()
            //    .Where(w => w.Length % 2 == 0)
            //    .ToArray();

            // foreach

            Console.ReadLine()
                .Split()
                .Where(w => w.Length % 2 == 0)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
