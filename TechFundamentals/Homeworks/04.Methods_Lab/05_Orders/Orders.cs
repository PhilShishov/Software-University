
namespace P05_Orders
{
    using System;

    class Orders
    {
        static void Main()
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintOrder(product, quantity);

        }

        static void PrintOrder(string product, int quantity)
        {
            double price = 0;
            if (product == "coffee")
            {
                price = 1.50;
            }
            else if (product == "water")
            {
                price = 1.00;
            }
            else if (product == "coke")
            {
                price = 1.40;
            }
            else if (product == "snacks")
            {
                price = 2.00;
            }

            double total = quantity * price;
            Console.WriteLine($"{total:F2}");
        }
    }
}
