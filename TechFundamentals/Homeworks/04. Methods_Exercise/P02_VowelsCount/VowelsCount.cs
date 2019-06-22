
namespace P02_VowelsCount
{
    using System;

    class VowelsCount
    {
        static void Main()
        {
            string text = Console.ReadLine();

            int result = CountVowels(text);
            Console.WriteLine(result);
        }

        public static int CountVowels(string text)
        {
            int vowels = 0;
            foreach (char letter in text)
            {
                if (letter == 'a' || letter == 'e' ||
                    letter == 'o' || letter == 'i' ||
                    letter == 'u' || letter == 'A' ||
                    letter == 'E' || letter == 'O' ||
                    letter == 'I' || letter == 'U')
                {
                    vowels++;
                }
            }
            return vowels;

        }
    }
}
