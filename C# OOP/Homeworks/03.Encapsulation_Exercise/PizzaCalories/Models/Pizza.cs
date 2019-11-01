namespace PizzaCalories
{
    using PizzaCalories.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }

        public string Name
        {
            get => this.name;

            private set
            {
                if (value.Length > 15 || string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidPizzaNameLength);
                }
                this.name = value;
            }
        }
        public IReadOnlyCollection<Topping> Toppings => this.toppings;

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidToppingsCount);
            }
            else
            {
                this.toppings.Add(topping);
            }
        }

        public double GetTotalCalories()
        {
            return this.Dough.GetTotalCalories() + this.toppings.Sum(t => t.GetTotalCalories());
        }
    }
}
