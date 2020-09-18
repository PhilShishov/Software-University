
namespace P02
{
    using System;

    public class Program
    {
        static void Main()
        {
            Action<string[]> printNames = names => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));
            string[] input = Console.ReadLine().Split();

            printNames(input);
        }
    }
}
