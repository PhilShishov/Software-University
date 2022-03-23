
namespace P04_ConvertMetersToKilometers
{
    using System;

    class ConvertMetersToKilometers
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());

            double km = m / 1000.0;

            Console.WriteLine($"{km:F2}");
        }
    }
}
