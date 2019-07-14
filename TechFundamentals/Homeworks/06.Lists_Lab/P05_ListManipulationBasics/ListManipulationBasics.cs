
namespace P05_ListManipulationBasics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListManipulationBasics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
