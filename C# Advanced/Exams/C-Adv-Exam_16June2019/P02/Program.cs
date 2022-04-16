
namespace P02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private const int TomatoCalories = 80;
        private const int CarrotCalories = 136;
        private const int LettuceCalories = 109;
        private const int PotatoCalories = 215;

        public static void Main()
        {
            var vegetablesInput = Console.ReadLine().Split();

            var caloriesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> saladCalories = new Stack<int>(caloriesInput);
            Queue<string> vegetables = new Queue<string>(vegetablesInput);

            List<int> finishedSalads = new List<int>();

            while (saladCalories.Count > 0 && vegetables.Count > 0)
            {
                int currentSalad = saladCalories.Peek();
                int finishedSalad = currentSalad;

                while (currentSalad > 0 && vegetables.Count > 0)
                {
                    string currentVeg = vegetables.Dequeue();

                    if (currentVeg == "tomato")
                    {
                        currentSalad -= TomatoCalories;
                    }
                    else if (currentVeg == "carrot")
                    {
                        currentSalad -= CarrotCalories;
                    }
                    else if (currentVeg == "potato")
                    {
                        currentSalad -= PotatoCalories;
                    }
                    else if (currentVeg == "lettuce")
                    {
                        currentSalad -= LettuceCalories;
                    }
                }

                saladCalories.Pop();
                finishedSalads.Add(finishedSalad);
            }

            Console.WriteLine(string.Join(" ", finishedSalads));

            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            if (saladCalories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", saladCalories));
            }
        }
    }
}