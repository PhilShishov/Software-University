using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(sequence);

            Console.WriteLine(orders.Max());

            while (orders.Count != 0)
            {
                int currentOrder = orders.Peek();

                if (currentOrder <= quantityFood)
                {
                    quantityFood -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
