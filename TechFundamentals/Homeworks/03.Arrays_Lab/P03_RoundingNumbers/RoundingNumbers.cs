
namespace P03_RoundingNumbers
{
    using System;
    using System.Linq;

    class RoundingNumbers
    {
        static void Main()
        {
            //string numbersAsText = Console.ReadLine();
            //string[] numbers = numbersAsText.Split();

            //double[] parsedNumbers = new double[numbers.Length];

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    parsedNumbers[i] = double.Parse(numbers[i]);
            //}

            //for (int i = 0; i < parsedNumbers.Length; i++)
            //{
            //    Console.WriteLine($"{parsedNumbers[i]} => {Math.Round(parsedNumbers[i], MidpointRounding.AwayFromZero)}");
            //}
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            string result = string.Join(' ', numbers);

            Console.WriteLine(result);

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine($"{numbers[i]} => " +
            //        $"{Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            //}


        }
    }
}
