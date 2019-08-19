using System;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = w => w[0] == w.ToUpper()[0];

            var text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper);

            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
    }
}
