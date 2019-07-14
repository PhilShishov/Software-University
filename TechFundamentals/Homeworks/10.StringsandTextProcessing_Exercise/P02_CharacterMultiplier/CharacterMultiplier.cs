
namespace P02_CharacterMultiplier
{
    using System;

    class CharacterMultiplier
    {
        static void Main()
        {

            string[] words = Console.ReadLine()
                .Split();

            string firstWord = words[0];
            string secondWord = words[1];

            int minLenght = Math.Min(firstWord.Length, secondWord.Length);
            int totalSum = 0;

            for (int i = 0; i < minLenght; i++)
            {
                totalSum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length > secondWord.Length)
            {
                totalSum += CalculateMissingCharacters(minLenght, firstWord);
            }

            else
            {
                totalSum += CalculateMissingCharacters(minLenght, secondWord);
            }

            Console.WriteLine(totalSum);
        }

        private static int CalculateMissingCharacters(int lenght, string word)
        {
            int totalSum = 0;

            for (int i = lenght; i < word.Length; i++)
            {
                totalSum += word[i];
            }

            return totalSum;
        }
    }
}
