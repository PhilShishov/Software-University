namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal InitialDrinkPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, InitialDrinkPrice, brand)
        {
        }
    }
}
