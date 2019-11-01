
namespace P04
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season season = (Season)Enum.Parse(typeof(Season), input[2]);
            DiscountType discountType = DiscountType.None;

            if (input.Length == 4)
            {
                discountType = (DiscountType)Enum.Parse(typeof(DiscountType), input[3]);
            }

            Console.WriteLine($"{PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, discountType, season):F2}");
        }
    }
}
