
namespace P06_ListManipulationAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListManipulationAdvanced
    {
        static void Main()
        {
            List<int> originalListNumbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            List<int> newListNumbers = new List<int>(originalListNumbers);

            while (true)
            {

                string input = Console.ReadLine();

                List<int> filtered;

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        newListNumbers.Add(numberToAdd);
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        newListNumbers.Remove(numberToRemove);
                        break;

                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        newListNumbers.RemoveAt(indexToRemove);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        newListNumbers.Insert(indexToInsert, numberToInsert);
                        break;

                    case "Contains":
                        int numberToCheck = int.Parse(tokens[1]);
                        bool check = newListNumbers.Contains(numberToCheck);
                        Console.WriteLine(check == true ? "Yes" : "No such number");
                        break;

                    case "PrintEven":
                        filtered = newListNumbers.Where(x => x % 2 == 0).ToList();
                        Console.WriteLine(string.Join(" ", filtered));
                        break;

                    case "PrintOdd":
                        filtered = newListNumbers.Where(x => x % 2 == 1).ToList();
                        Console.WriteLine(string.Join(" ", filtered));
                        break;

                    case "GetSum":
                        Console.WriteLine(newListNumbers.Sum());
                        break;

                    case "Filter":
                        string condition = tokens[1];
                        int numberToFilter = int.Parse(tokens[2]);                        

                        if (condition == "<")
                        {
                            filtered = newListNumbers.Where(x => x < numberToFilter).ToList();
                        }
                        else if (condition == "<=")
                        {
                            filtered = newListNumbers.Where(x => x <= numberToFilter).ToList();
                        }
                        else if (condition == ">")
                        {
                            filtered = newListNumbers.Where(x => x > numberToFilter).ToList();
                        }
                        else if (condition == ">=")
                        {
                            filtered = newListNumbers.Where(x => x >= numberToFilter).ToList();
                        }
                        else
                        {
                            break;
                        }
                        Console.WriteLine(string.Join(" ", filtered));
                        break;
                }

            }

            bool compareLists = newListNumbers.SequenceEqual(originalListNumbers);

            if (!compareLists)
            {
                Console.WriteLine(string.Join(" ", newListNumbers));
            }
        }
    }
}
