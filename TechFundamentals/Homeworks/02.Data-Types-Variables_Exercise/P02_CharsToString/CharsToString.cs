
namespace P02_CharsToString
{
    using System;

    class CharsToString
    {
        static void Main(string[] args)
        {
            //string inputOne = Console.ReadLine();
            //string inputTwo = Console.ReadLine();
            //string inputThree = Console.ReadLine();

            //Console.WriteLine($"{inputOne}{inputTwo}{inputThree}");

            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            string output = a.ToString() + b.ToString() + c.ToString();

            Console.WriteLine(output);
        }
    }
}
