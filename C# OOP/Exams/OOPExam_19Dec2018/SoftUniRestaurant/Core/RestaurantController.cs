namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private decimal income = 0;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = null;

            if (type == "Dessert")
            {
                food = new Dessert(name, price);
            }
            else if (type == "Salad")
            {
                food = new Salad(name, price);
            }

            else if (type == "Soup")
            {
                food = new Soup(name, price);
            }

            else if (type == "MainCourse")
            {
                food = new MainCourse(name, price);
            }

            if (food != null)
            {
                this.menu.Add(food);
            }


            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:F2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;

            if (type == "Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
            }
            else if (type == "FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
            }

            else if (type == "Juice")
            {
                drink = new Juice(name, servingSize, brand);
            }

            else if (type == "Water")
            {
                drink = new Water(name, servingSize, brand);
            }

            if (drink != null)
            {
                this.drinks.Add(drink);
            }

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "Inside")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "Outside")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table != null)
            {
                this.tables.Add(table);
            }

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            income += bill;

            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:F2}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
               sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = this.tables.Where(t => t.IsReserved == true).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in occupiedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.income:F2}lv";
        }
    }
}
