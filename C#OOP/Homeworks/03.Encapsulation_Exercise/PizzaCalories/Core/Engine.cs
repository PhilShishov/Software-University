namespace PizzaCalories
{
    using PizzaCalories.Exceptions;
    using System;

    public class Engine
    {
        public void Run()
        {
            Dough dough = null;
            Topping topping = null;
            Pizza pizza = null;

            try
            {
                string input = Console.ReadLine();
                while (input != "end")
                {
                    var pizzaInput = input.Split();
                    string pizzaName = pizzaInput[1];

                    input = Console.ReadLine().ToLower();

                    dough = CreateDough(input);

                    pizza = new Pizza(pizzaName, dough);

                    input = Console.ReadLine().ToLower();

                    while (input != "end")
                    {
                        topping = CreateTopping(input);
                        pizza.AddTopping(topping);

                        input = Console.ReadLine().ToLower();
                    }
                }

                //Console.WriteLine($"{dough.GetTotalCalories():F2}");
                //Console.WriteLine($"{topping.GetTotalCalories():F2}");

                double result = pizza.GetTotalCalories();

                Console.WriteLine($"{pizza.Name} - {result:F2} Calories.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Topping CreateTopping(string input)
        {
            Topping topping;
            var toppingInput = input.Split();

            string toppingType = toppingInput[1];
            int weight = int.Parse(toppingInput[2]);

            topping = new Topping(toppingType, weight);
            return topping;
        }

        private static Dough CreateDough(string input)
        {
            Dough dough;
            var doughInput = input.Split();

            string flourType = doughInput[1];
            string bakingTechnique = doughInput[2];
            int weight = int.Parse(doughInput[3]);

            dough = new Dough(flourType, bakingTechnique, weight);
            return dough;
        }
    }
}
