namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private const int GlassValue = 25;
        private const int AluminiumValue = 50;
        private const int LithiumValue = 75;
        private const int CarbonFiberValue = 100;

        public static void Main(string[] args)
        {
            var liquidsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var itemsInput = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> items = new Stack<int>(itemsInput);

            var advancedMaterials = new Dictionary<string, int>();

            advancedMaterials.Add("Aluminium", 0);
            advancedMaterials.Add("Glass", 0);
            advancedMaterials.Add("Lithium", 0);
            advancedMaterials.Add("Carbon fiber", 0);

            while (items.Count > 0 && liquids.Count > 0)
            {
                int currentItem = items.Pop();
                int currentLiquid = liquids.Dequeue();
                int result = currentItem + currentLiquid;

                if (result == GlassValue)
                {
                    advancedMaterials["Glass"]++;
                }
                else if (result == AluminiumValue)
                {
                    advancedMaterials["Aluminium"]++;
                }

                else if (result == LithiumValue)
                {
                    advancedMaterials["Lithium"]++;
                }
                else if (result == CarbonFiberValue)
                {
                    advancedMaterials["Carbon fiber"]++;
                }
                else
                {
                    items.Push(currentItem + 3);
                }
            }

            if (advancedMaterials.Values.All(am => am > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            }

            if (items.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine("Physical items left: " + string.Join(", ", items));
            }

            foreach (var material in advancedMaterials.OrderBy(am => am.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
