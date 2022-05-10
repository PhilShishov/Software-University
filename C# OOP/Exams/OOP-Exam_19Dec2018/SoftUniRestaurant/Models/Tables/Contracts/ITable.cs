
namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;

    using System.Collections.Generic;

    public interface ITable
    {
        IReadOnlyCollection<IFood> Foods { get; }

        IReadOnlyCollection<IDrink> Drinks { get; }

        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; set; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; set; }

        decimal Price { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();

    }
}
