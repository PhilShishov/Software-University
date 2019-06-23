
namespace P04_ListOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOperations
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);

                        if (indexToInsert > numbers.Count - 1 || indexToInsert < 0)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(indexToInsert, numberToInsert);
                        }
                        break;

                    case "Remove":
                        int indexToRemove = int.Parse(tokens[1]);

                        if (indexToRemove > numbers.Count || indexToRemove < 0)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(indexToRemove);
                        }
                        break;

                    case "Shift":

                        string direction = tokens[1];
                        int rotations = int.Parse(tokens[2]);

                        if (direction == "left")
                        {
                            for (int i = 0; i < rotations % numbers.Count; i++)
                            {
                                int firstNumber = numbers[0];

                                for (int j = 0; j < numbers.Count - 1; j++)
                                {
                                    numbers[j] = numbers[j + 1];
                                }

                                numbers[numbers.Count - 1] = firstNumber;
                            }
                        }

                        else
                        {
                            for (int i = 0; i < rotations % numbers.Count; i++)
                            {
                                int lastNumber = numbers[numbers.Count - 1];

                                for (int j = numbers.Count - 1; j > 0; j--)
                                {
                                    numbers[j] = numbers[j - 1];
                                }

                                numbers[0] = lastNumber;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
