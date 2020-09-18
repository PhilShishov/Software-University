
namespace P02_Deciphering
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Deciphering
    {
        static void Main()
        {
            string textToDecipher = Console.ReadLine();
            string[] substrings = Console.ReadLine().Split();

            //char[] allowedCharacters = {'{', '}', '|', '#'};

            //if (!textToDecipher.All(c => (c>= 100 && c<= 122) || allowedCharacters.Contains(c)))
            //{
            //    Console.WriteLine("This is not the book you are looking for.");
            //}

            string decipherPattern = @"\b^[d-z#|{}]+\b";
            Match decipherMatch = Regex.Match(textToDecipher, decipherPattern);

            if (!decipherMatch.Success)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            textToDecipher = new string(textToDecipher
                .Select(c => (char)(c - 3))
                .ToArray());

            string stringToRemplace = substrings[0];
            string replacementString = substrings[1];

            textToDecipher = textToDecipher.Replace(stringToRemplace, replacementString);

            Console.WriteLine(textToDecipher);
        }
    }
}
