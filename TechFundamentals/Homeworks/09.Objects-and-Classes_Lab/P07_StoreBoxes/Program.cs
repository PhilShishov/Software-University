
namespace P07_StoreBoxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();

                string serialNumber = tokens[0];
                string name = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = decimal.Parse(tokens[3]);

                var box = new Box();

                box.SerialNumber = serialNumber;
                box.Item.Name = name;
                box.Quantity = quantity;
                box.Item.Price = price;
                box.PriceBox = quantity * price;

                boxes.Add(box);
            }

            foreach (var  box in boxes.OrderByDescending(b => b.PriceBox))
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }
    }
}
