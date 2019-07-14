
namespace P02_RandomizeWords
{
    using System;

    class RandomizeWords
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();

            var random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int ri = random.Next(0, words.Length);

                var tempValue = words[i];
                words[i] = words[ri];
                words[ri] = tempValue;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));

        }
    }
}
