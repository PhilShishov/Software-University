namespace WildFarm.Models.Foods.Entities
{
    using WildFarm.Models.Foods.Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }


    }
}
