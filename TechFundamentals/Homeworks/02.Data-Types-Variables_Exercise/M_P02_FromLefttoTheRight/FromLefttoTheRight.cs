
namespace M_P02_FromLefttoTheRight
{
    using System;

    class FromLefttoTheRight
    {
        static void SummingDigits(long number)
        {
            long sum = 0;
            number = Math.Abs(number);
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string twoIntegers = Console.ReadLine();
                string firstInteger = "";
                string secondInteger = "";

                int indexOfSpace = twoIntegers.IndexOf(' ');

                for (int a = 0; a < indexOfSpace; a++)
                {
                    firstInteger += twoIntegers[a];
                }

                for (int b = indexOfSpace + 1; b < twoIntegers.Length; b++)
                {
                    secondInteger += twoIntegers[b];
                }

                long.TryParse(firstInteger, out long firstNumber);
                long.TryParse(secondInteger, out long secondNumber);

                if (firstNumber > secondNumber)
                {
                    SummingDigits(firstNumber);
                }
                else
                {
                    SummingDigits(secondNumber);
                }
            }
        }
    }
}
