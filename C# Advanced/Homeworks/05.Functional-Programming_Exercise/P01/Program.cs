
namespace P01
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            string[] input = Console.ReadLine().Split();

            print(input);
        }
    }
}
