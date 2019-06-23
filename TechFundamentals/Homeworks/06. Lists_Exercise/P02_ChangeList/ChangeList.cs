
namespace P02_ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ChangeList
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();                

                switch (tokens[0])
                {
                    case "Delete":
                        int numberToDelete = int.Parse(tokens[1]);
                        numbers.RemoveAll(x => x == numberToDelete);
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
