
namespace P09_PalindromeIntegers
{
    using System;

    class PalindromeIntegers
    {
        static void Main()
        {
            while (true)
            {
                string word = Console.ReadLine();

                if (word == "END")
                {
                    break;
                }
                string reversedWord = ReversedWord(word);

                bool isPalindrome = IsPalindrome(word, reversedWord);

                Console.WriteLine(isPalindrome? "true" : "false");
            }
        }

        private static string ReversedWord(string word)
        {
            string reversedWord = string.Empty;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += word[i];
            }
            return reversedWord;
        }

        private static bool IsPalindrome(string word, string reversedWord)
        {
            return word == reversedWord;
        }
    }
}
