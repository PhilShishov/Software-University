
namespace _08_ConcatNames
{
    using System;

    class ConcatNames
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string delimiter = Console.ReadLine();

            //Console.WriteLine($"{name1}{delimiter}{name2}");

            string result = name1 + delimiter + name2;
            Console.WriteLine(result);

        }
    }
}
