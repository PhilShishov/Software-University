namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        private const decimal InitialDrinkPrice = 1.80m;

        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, InitialDrinkPrice, brand)
        {
        }
    }
}
