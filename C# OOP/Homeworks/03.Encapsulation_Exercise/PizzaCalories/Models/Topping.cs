namespace PizzaCalories
{
    using PizzaCalories.Exceptions;
    using System;
    using System.Globalization;

    public class Topping
    {
        private const int BaseCalories = 2;

        private string toppingType;
        private int weight;
        private double modifierTopping;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => this.toppingType;

            private set
            {
                if (value == "meat")
                {
                    this.modifierTopping = 1.2;
                }

                else if (value == "veggies")
                {
                    this.modifierTopping = 0.8;
                }

                else if (value == "cheese")
                {
                    this.modifierTopping = 1.1;
                }

                else if (value == "sauce")
                {
                    this.modifierTopping = 0.9;
                }

                else
                {                    
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidToppingType, ToTitleCase(value)));
                }
                this.toppingType = value;
            }
        }        

        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidToppingWeight, ToTitleCase(this.ToppingType)));
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.modifierTopping * (this.Weight * BaseCalories);
        }

        private static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}
