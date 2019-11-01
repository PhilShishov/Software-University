namespace SoftUniRestaurant.Models.Drinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Water: Drink
    {
        private const decimal InitialDrinkPrice = 1.50m;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, InitialDrinkPrice, brand)
        {
        }
    }
}
