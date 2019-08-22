using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            var elementToCompare = Console.ReadLine();          

            Console.WriteLine(box.Compare(elementToCompare));
        }
    }
}
