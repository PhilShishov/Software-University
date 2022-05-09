namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using INStock.Contracts;
    using INStock.Models;

    using NUnit.Framework;

    [TestFixture]
    public class InStockTestsPerformance
    {
        private const int TEN_THOUSAND = 10_000;
        private IProductStock stock;
        private Stopwatch sw;
        private Random rand;
        private List<Product> products;

        [SetUp]
        public void Setup()
        {
            this.stock = new ProductStock();
            this.sw = new Stopwatch();
            this.rand = new Random();
            this.products = new List<Product>();
        }

        [Test]
        public void Add_10000_Elements_ShouldWorkFast()
        {
            sw.Start();
            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                int value = rand.Next(1, TEN_THOUSAND);
                stock.Add(new Product(i.ToString(), value, value));
            }
            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 450);
        }

        [Test]
        public void Contains_10000_Elements_ShouldExecuteFast()
        {
            LinkedList<Product> productsLinked = new LinkedList<Product>();
            for (int i = 1; i < TEN_THOUSAND; i++)
            {
                productsLinked.AddLast(new Product(i.ToString(), i, i));
                stock.Add(productsLinked.Last.Value);
            }

            sw.Start();
            var node = productsLinked.First;
            while (node != null)
            {
                Assert.True(stock.Contains(node.Value));
                node = node.Next;
            }

            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 300);
        }

        [Test]
        public void FindAtIndex_On_10_000_Elements_ShouldWorkFast()
        {
            for (int i = 1; i < TEN_THOUSAND; i++)
            {
                products.Add(new Product(i.ToString(), i, i));
                stock.Add(products[i - 1]);
            }

            sw.Start();
            for (int i = 0; i < 5000; i++)
            {
                int rnd = rand.Next(0, 10);
                Assert.AreEqual(products[rnd], stock.Find(rnd));
            }

            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 200);
        }

        [Test]
        public void Add_Many_Count_ShouldWork()
        {
            for (int i = 1; i < TEN_THOUSAND; i++)
            {
                Assert.AreEqual(i - 1, stock.Count);
                stock.Add(new Product(i.ToString(), i, i));
            }
        }

        [Test]
        public void FindByLabel_Should_WorkFast_On_10000_Products()
        {
            var names = new List<KeyValuePair<string, Product>>(TEN_THOUSAND);

            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                int price_quantity = i + 1;
                var p = new Product(i.ToString(), price_quantity, price_quantity);
                stock.Add(p);
                names.Add(new KeyValuePair<string, Product>(p.Label, p));
            }

            sw.Start();
            bool Result(int index)
            {
                return stock.FindByLabel(names[index].Key) == names[index].Value;
            }

            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                Assert.True(Result(i));
            }

            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 250);
        }

        [Test]
        public void ProductByInsertOrder_ShouldWorkFast()
        {
            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                int price_quantity = i + 1;
                products.Add(new Product(i.ToString(), price_quantity, price_quantity));
                stock.Add(products[i]);
            }

            sw.Start();

            CollectionAssert.AreEqual(products, stock.ToList());
            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 150);
        }

        [Test]
        public void FindAllByPrice_On10000ElementsWithRandomPrice_ShouldWorkFast()
        {
            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                int price = rand.Next(5, 30);
                var p = new Product(i.ToString(), price, 25);
                if (price == 21)
                {
                    products.Add(p);
                }
                stock.Add(p);
            }

            sw.Start();
            IEnumerable<IProduct> FindAllByPrice() => stock.FindAllByPrice(21);

            CollectionAssert.AreEqual(products, FindAllByPrice());
            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 25);
        }

        [Test]
        public void FindAllByQuantity_On_10000_Elements_ShouldWorkFast()
        {
            var expected = new Dictionary<int, List<IProduct>>();

            for (int i = 0; i < TEN_THOUSAND; i += 400)
            {
                for (int j = 0; j < 400; j++)
                {
                    int price_quantity = j + 1;
                    var p = new Product((i + j).ToString(), price_quantity, price_quantity);
                    if (!expected.ContainsKey(j))
                    {
                        expected[j] = new List<IProduct>();
                    }
                    stock.Add(p);
                    expected[j].Add(p);
                }
            }
            sw.Start();

            IEnumerable<IProduct> Result(int qty) => stock.FindAllByQuantity(qty);

            for (int i = 0; i < 100; i++)
            {
                CollectionAssert.AreEqual(expected[i], Result(i + 1));
            }
            sw.Stop();

            Assert.Less(sw.ElapsedMilliseconds, 100);
        }

        [Test]
        public void FindAllInPriceRange_OnLargeRange_ShouldWorkFast()
        {
            int expected = 0;

            for (int i = 0; i < TEN_THOUSAND; i++)
            {
                int price = rand.Next(10, 5000);
                if (price > 105 && price <= 1000)
                {
                    expected++;
                    int quantity = i + 1;

                    stock.Add(new Product(i.ToString(), price, quantity));
                }
            }

            sw.Start();

            IEnumerable<IProduct> FindInPriceRange() => stock.FindAllInRange(105, 1000);

            Assert.AreEqual(expected, FindInPriceRange().Count());

            sw.Stop();
            Assert.Less(sw.ElapsedMilliseconds, 300);
        }
    }
}
