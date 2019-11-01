namespace PizzaCalories
{
    using PizzaCalories.Exceptions;
    using System;

    public class Dough
    {
        private const int BaseCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double modifierFlour;
        private double modifierBaking;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (value == "white")
                {
                    this.modifierFlour = 1.5;
                }
                else if (value == "wholegrain")
                {
                    this.modifierFlour = 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (value == "crispy")
                {
                    this.modifierBaking = 0.9;
                }
                else if (value == "chewy")
                {
                    this.modifierBaking = 1.1;
                }
                else if (value == "homemade")
                {
                    this.modifierBaking = 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidDoughWeight);
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.modifierFlour * this.modifierBaking * (this.Weight * BaseCalories);
        }

    }
}
