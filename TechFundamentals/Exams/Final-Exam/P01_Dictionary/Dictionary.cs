
namespace P01_Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Dictionary
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, List<string>>();

            string[] pairOfWordsDefinitions = Console.ReadLine().Split(" | ");

            foreach (var pair in pairOfWordsDefinitions)
            {
                string[] splitted = pair.Split(": ");

                string word = splitted[0];
                string definition = splitted[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }

                dictionary[word].Add(definition);
            }

            string[] wordsToPrint = Console.ReadLine().Split(" | ");

            foreach (var word in wordsToPrint.OrderBy(w => w))
            {
                if (dictionary.ContainsKey(word))
                {
                    Console.WriteLine(word);
                    foreach (var definition in dictionary[word].OrderByDescending(d => d.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }

            }

            string command = Console.ReadLine();

            if (command == "List")
            {
                Console.WriteLine(string.Join(" ", dictionary.Keys.OrderBy(w => w)));
            }

            else
            {
                return;
            }
        }
    }
}
