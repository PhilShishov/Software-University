
namespace P03_PostOffice
{
    using System;
    using System.Text.RegularExpressions;

    class PostOffice
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPard = input[2];

            string firstPattern = @"([#$*&%])(?<capitalLetters>[A-Z]+)(\1)";
            Match firstMatch = Regex.Match(firstPart, firstPattern);
            string letters = firstMatch.Groups["capitalLetters"].Value;

            for (int index = 0; index < letters.Length; index++)
            {
                char currentLetter = letters[index];
                int asciiCode = currentLetter;

                string secondPattern = $@"{asciiCode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, secondPattern);
                int length = int.Parse(secondMatch.Groups["length"].Value);

                string thirdPattern = $@"(?<=\s|^){currentLetter}[^\s]{{{length}}}(?=\s|$)";
                Match thirdMatch = Regex.Match(thirdPard, thirdPattern);
                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }
        }
    }
}
