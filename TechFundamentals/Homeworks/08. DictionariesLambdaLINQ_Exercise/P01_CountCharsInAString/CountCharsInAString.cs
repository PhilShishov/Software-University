
namespace P01_CountCharsInAString
{
    using System;
    using System.Collections.Generic;

    class CountCharsInAString
    {
        static void Main()
        {
            string words = Console.ReadLine();
            char[] word = words.ToCharArray();

            var counts = new Dictionary<char, int>();

            foreach (var letter in word)
            {
                if (letter != ' ')
                {
                    if (counts.ContainsKey(letter))
                    {
                        counts[letter]++;
                    }

                    else
                    {
                        counts.Add(letter, 1);
                    }
                }
            }

            foreach (var letter in counts)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
