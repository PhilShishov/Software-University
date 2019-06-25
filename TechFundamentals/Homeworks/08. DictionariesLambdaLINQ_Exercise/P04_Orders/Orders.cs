
namespace P04_Orders
{
    using System;
    using System.Collections.Generic;

    class Orders
    {
        static void Main()
        {
            var productsQuantity = new Dictionary<string, int>();
            var productsPrice = new Dictionary<string, decimal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();

                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);


                if (!productsPrice.ContainsKey(product))
                {
                    productsQuantity[product] = quantity;
                }
                else
                {
                    productsQuantity[product] += quantity;
                }

                productsPrice[product] = price;
            }

            foreach (var kvp in productsQuantity)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                decimal price = productsPrice[product];
                decimal result = quantity * price;

                Console.WriteLine($"{product} -> {result:F2}");

            }
        }
    }
}
