
namespace P03_CharactersinRange
{
    using System;

    class CharactersinRange
    {
        static void Main()
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            PrintCharacters(first, second);

        }
        public static void PrintCharacters(char first, char second)
        {
            if (second < first)
            {
                for (char n = (char)(second + 1); n < first; n++)
                {
                    Console.Write(n + " ");
                }
            }

            else
            {
                for (char i = (char)(first + 1); i < second; i++)
                {
                    Console.Write(i + " ");

                }
            }
            Console.WriteLine();
        }
    }
}
