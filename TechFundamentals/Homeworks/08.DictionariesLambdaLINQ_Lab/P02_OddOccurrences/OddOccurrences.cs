
namespace P02_OddOccurrences
{
    using System;
    using System.Collections.Generic;

    class OddOccurrences
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();

            var dict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordInLowerCase = word.ToLower();
                if (dict.ContainsKey(wordInLowerCase))
                {
                    dict[wordInLowerCase]++;
                }
                else
                {
                    dict.Add(wordInLowerCase, 1);
                }
            }

            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 1)
                {
                    Console.Write(kvp.Key + " ");
                }
            }

        }
    }
}
