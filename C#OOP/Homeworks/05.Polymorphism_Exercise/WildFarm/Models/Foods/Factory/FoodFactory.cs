namespace WildFarm.Models.Foods.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using WildFarm.Models.Foods.Contracts;

    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            //IFood food;

            //if (type == "Vegetable")
            //{
            //    food = new Vegetable(quantity);
            //}

            //else if (type == "Fruit")
            //{
            //    food = new Fruit(quantity);
            //}

            //else if (type == "Meat")
            //{
            //    food = new Meat(quantity);
            //}

            //else if (type == "Seeds")
            //{
            //    food = new Seeds(quantity);
            //}

            //else
            //{
            //    throw new InvalidOperationException("Invalid food type");
            //}

            // True Factory

            Type typeR = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == type.ToLower());

            if (typeR == null)
            {
                throw new InvalidOperationException("Not supported type!");
            }

            object[] args = new object[]
            {
                quantity
            };

            IFood food = (IFood)Activator.CreateInstance(typeR, args);

            return food;
        }
    }
}
