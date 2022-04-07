﻿
namespace P12_CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> cupsCapacity = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> filledBottels = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int wastedWater = 0;

            while (cupsCapacity.Count != 0 && filledBottels.Count != 0)
            {
                int currentCup = cupsCapacity[0];
                int currentBottle = filledBottels.Last();

                if (currentCup - currentBottle <= 0)
                {
                    cupsCapacity.RemoveAt(0);
                    wastedWater += Math.Abs(currentBottle - currentCup);
                    filledBottels.RemoveAt(filledBottels.Count - 1);
                }
                else
                {
                    while (true)
                    {
                        if (currentCup - currentBottle <= 0)
                        {
                            cupsCapacity.RemoveAt(0);
                            wastedWater += Math.Abs(currentBottle - currentCup);
                            filledBottels.RemoveAt(filledBottels.Count - 1);
                            break;
                        }
                        else
                        {
                            currentCup -= currentBottle;
                            filledBottels.RemoveAt(filledBottels.Count - 1);
                            currentBottle = filledBottels.Last();
                        }
                    }
                }
            }

            if (cupsCapacity.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", filledBottels)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
