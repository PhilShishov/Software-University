
namespace HealthyHeaven
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // Initialize the repository
            var restaurant = new Restaurant("Casa Domingo");

            // Initialize the entities
            var tomato = new Vegetable("Tomato", 20);
            var cucumber = new Vegetable("Cucumber", 15);

            var salad = new Salad("Tomatoes with cucumbers");

            salad.Add(tomato);
            salad.Add(cucumber);

            Console.WriteLine(salad.GetTotalCalories()); // 35
            Console.WriteLine(salad.GetProductCount());  // 2

            Console.WriteLine(salad.ToString());
            // * Salad Tomatoes with cucumbers is 35 calories and have 2 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories

            restaurant.Add(salad);

            Console.WriteLine(restaurant.Buy("Invalid salad")); // False

            // Initialize the second entities
            var corn = new Vegetable("Corn", 90);
            var casaDomingo = new Salad("Casa Domingo");

            casaDomingo.Add(tomato);
            casaDomingo.Add(cucumber);
            casaDomingo.Add(corn);

            restaurant.Add(casaDomingo);

            Console.WriteLine(restaurant.GetHealthiestSalad()); // Tomatoes with cucumbers

            Console.WriteLine(restaurant.GenerateMenu());
            // Casa Domingo have 2 salads:
            // * Salad Tomatoes with cucumbers is 35 calories and have 2 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories
            // * Salad Casa Domingo is 125 calories and have 3 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories
            //  - Corn have 90 calories

        }
    }
}