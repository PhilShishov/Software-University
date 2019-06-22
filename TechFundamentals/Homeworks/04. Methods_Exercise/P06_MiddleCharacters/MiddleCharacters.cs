
namespace P06_MiddleCharacters
{
    using System;

    class MiddleCharacters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            PrintMiddleCharacter(input);
        }

        public static void PrintMiddleCharacter(string input)
        {
            int middleChar = input.Length / 2;
            char firstSymbol = input[middleChar];
            char secondSymbol = input[middleChar - 1];

            Console.WriteLine(input.Length % 2 == 1 ? $"{firstSymbol}" : $"{secondSymbol}{firstSymbol}");            
        }
    }
}
