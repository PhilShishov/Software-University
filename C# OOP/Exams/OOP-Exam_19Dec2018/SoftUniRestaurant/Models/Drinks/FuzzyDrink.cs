namespace SoftUniRestaurant.Models.Drinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class FuzzyDrink : Drink
    {
        private const decimal InitialDrinkPrice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, InitialDrinkPrice, brand)
        {
        }
    }
}
