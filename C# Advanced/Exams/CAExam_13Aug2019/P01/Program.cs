using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    public class Program
    {
        private const int freshnessMimosa = 150;
        private const int freshnessDaiquiri = 250;
        private const int freshnessSunshine = 300;
        private const int freshnessMojito = 400;

        public static void Main(string[] args)
        {
            var ingredientsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var freshnessLevelInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientsInput);
            Stack<int> freshnessLevel = new Stack<int>(freshnessLevelInput);
            var cocktails = new Dictionary<string, int>();

            cocktails.Add("Mimosa", 0);
            cocktails.Add("Daiquiri", 0);
            cocktails.Add("Sunshine", 0);
            cocktails.Add("Mojito", 0);

            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }
                int currentFreshness = freshnessLevel.Pop();

                if (currentIngredient * currentFreshness == freshnessMimosa)
                {
                    cocktails["Mimosa"]++;
                }

                else if (currentIngredient * currentFreshness == freshnessDaiquiri)
                {
                    cocktails["Daiquiri"]++;
                }

                else if (currentIngredient * currentFreshness == freshnessSunshine)
                {
                    cocktails["Sunshine"]++;
                }

                else if (currentIngredient * currentFreshness == freshnessMojito)
                {
                    cocktails["Mojito"]++;
                }

                else
                {
                    ingredients.Enqueue(currentIngredient + 5);
                }

                //if (cocktails.Values.All(c => c > 0))
                //{
                //    break;
                //}

            }

            var preraredCocktails = cocktails.Where(c => c.Value > 0).ToList();

            if (cocktails.Values.All(c => c > 0))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }

            else if (!cocktails.Values.All(c => c > 0))
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in preraredCocktails.OrderBy(c => c.Key))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }


        }
    }
}
