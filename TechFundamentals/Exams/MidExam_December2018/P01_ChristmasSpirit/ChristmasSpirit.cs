using System;

namespace P01_ChristmasSpirit
{
    class ChristmasSpirit
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int priceOrnament = 2;
            int priceSkirt = 5;
            int priceGarlands = 3;
            int priceLights = 15;

            int spirit = 0;
            int budget = 0;
            bool lastDay = days % 10 == 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 == 0)
                {
                    budget += priceOrnament * quantity;
                    spirit += 5;
                }
                if (i % 3 == 0)
                {
                    budget += (priceSkirt * quantity) + (priceGarlands * quantity);
                    spirit += 13;
                }
                if (i % 5 == 0)
                {
                    budget += priceLights * quantity;
                    spirit += 17;
                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }
                if (i % 10 == 0)
                {
                    budget += priceSkirt + priceGarlands + priceLights;
                    spirit -= 20;
                }

                if (lastDay && i == days)
                {
                    spirit -= 30;
                }
            }

            Console.WriteLine($"Total cost: {budget}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
