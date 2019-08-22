using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < lines; i++)
            {
                var currentString = int.Parse(Console.ReadLine());
                box.Add(currentString);
            }
            var inputIndex = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = inputIndex[0];
            int secondIndex = inputIndex[1];

            Swap(box.Data, firstIndex, secondIndex);

            Console.WriteLine(box.ToString());
        }

        private static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
