namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Person> peopleBag;
        private readonly List<Product> products;

        public Engine()
        {
            this.peopleBag = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                AddPeople();
                AddProducts();

                string ordersInput = Console.ReadLine();

                while (ordersInput != "END")
                {
                    var input = ordersInput.Split();
                    string personName = input[0];
                    string productName = input[1];

                    Person targetPerson = peopleBag.FirstOrDefault(p => p.Name == personName);
                    Product targetProduct = products.FirstOrDefault(p => p.Name == productName);

                    if (targetPerson != null && targetProduct != null)
                    {
                        targetPerson.BuyProduct(targetProduct);
                    }                    

                    ordersInput = Console.ReadLine();
                }

                foreach (var person in peopleBag)
                {
                    if (person.Products.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }

                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
                    }
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private void AddProducts()
        {
            var productsInput = Console.ReadLine().Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var input in productsInput)
            {
                var inputArgs = input.Split("=");
                string name = inputArgs[0];
                int cost = int.Parse(inputArgs[1]);

                Product product = new Product(name, cost);

                this.products.Add(product);
            }
        }

        private void AddPeople()
        {
            var peopleInput = Console.ReadLine().Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var input in peopleInput)
            {
                var inputArgs = input.Split("=");
                string name = inputArgs[0];
                int money = int.Parse(inputArgs[1]);

                Person person = new Person(name, money);

                this.peopleBag.Add(person);
            }
        }
    }
}
