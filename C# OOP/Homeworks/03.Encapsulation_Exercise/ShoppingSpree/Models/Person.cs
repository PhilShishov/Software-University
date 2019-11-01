namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products => this.bagOfProducts.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }

            else if (this.Money - product.Cost < 0)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }       
    }
}

