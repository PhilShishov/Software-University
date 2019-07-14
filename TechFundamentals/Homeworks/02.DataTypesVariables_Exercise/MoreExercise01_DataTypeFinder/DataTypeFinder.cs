
namespace MoreExercise01_DataTypeFinder
{
    using System;

    class DataTypeFinder
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int integer;
            double floating;
            char character;
            bool boolean;

            while (input != "END")
            {
                input = Console.ReadLine();

                bool isInteger = int.TryParse(input, out integer);
                bool isFloatingPoint = double.TryParse(input, out floating);
                bool isCharacter = char.TryParse(input, out character);
                bool isBoolean = bool.TryParse(input, out boolean);

                if (isInteger)
                {
                    Console.WriteLine($"{input} is integer type");
                }

                else if (isFloatingPoint)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isCharacter)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (isBoolean)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (input != "END")
                {
                    Console.WriteLine($"{input} is string type");
                }
            }

        }
    }
}
