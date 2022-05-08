namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using INStock.Contracts;
    using INStock.Models;

    using NUnit.Framework;

    [TestFixture]
    public class InStockTestsCorrectness
    {
        private IProductStock stock;
        private Product product1;
        private Product product2;
        private Product product3;
        private Product product4;
        private Product product5;
        private Product product6;
        private Product product7;

        [SetUp]
        public void Setup()
        {
            this.stock = new ProductStock();
            this.product1 = new Product("Water", 0.50m, 50);
            this.product2 = new Product("Laptop", 206.1m, 67);
            this.product3 = new Product("Charger", 5, 8);
            this.product4 = new Product("Screen", 50, 10);
            this.product5 = new Product("Mouse", 20, 10);
            this.product6 = new Product("Phone", 150, 2);
            this.product7 = new Product("50CentPoster", 0.50m, 5);
        }

        [Test]
        public void Add_Single_Product_ShouldAddProduct()
        {
            stock.Add(product1);

            foreach (var item in stock)
            {
                if (item == product1
                    && (product1.Price == item.Price
                    && product1.Label == item.Label
                    && product1.Quantity == item.Quantity))
                {
                    Assert.Pass();
                }
            }
        }

        [Test]
        public void Add_MultipleElements_Should_Increase_Count()
        {
            AddThreeProducts();

            Assert.AreEqual(3, stock.Count, "Count should increase with every item.");
        }

        [Test]
        public void Add_MultipleElements_ShouldWorkCorrectly()
        {
            AddThreeProducts();

            Assert.AreEqual(product1, stock.Find(0));
            Assert.AreEqual(product2, stock.Find(1));
            Assert.AreEqual(product3, stock.Find(2));
        }

        [Test]
        public void Add_SingleElement_Contains_ShouldReturnTrue()
        {
            stock.Add(product1);

            var actual = stock.Contains(product1);
            Assert.True(actual, "Contains on existing element return true");
        }

        [Test]
        public void Contains_On_Non_ExistingElement_ShouldReturnFalse()
        {
            stock.Add(product1);

            var actual = stock.Contains(product2);
            Assert.False(actual, "Contains on non-existing element should return false");
        }

        [Test]
        public void Contains_On_Empty_Collection_ShouldReturnFalse()
        {
            Assert.IsFalse(stock.Contains(new Product("Non existant", 5.5m, 15)));
        }

        [Test]
        public void Find_Product_On_ExistingProduct_ShouldWorkCorrectly()
        {
            AddThreeProducts();

            Assert.AreSame(product3, stock.Find(2));
            Assert.AreNotSame(product1, stock.Find(1));
            Assert.AreSame(product1, stock.Find(0));
        }

        [Test]
        public void ChangeQuantity_On_ExistingProduct_ShouldWorkCorrectly()
        {
            AddThreeProducts();

            stock.ChangeQuantity("Charger", 3);
            int expected = 3;
            int actual = stock.FindByLabel("Charger").Quantity;
            //Assert
            Assert.AreEqual(3, stock.Count);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_Single_Product_ShouldBeAt_0_Index()
        {
            stock.Add(product1);
            Assert.AreEqual(product1, stock.Find(0), "Added item should be on index 0");
        }

        [Test]
        public void ChangeQuantity_On_NonExisting_Product_ShouldThrow()
        {
            AddThreeProducts();

            Assert.Throws<ArgumentException>(() => stock.ChangeQuantity("Non existing", 0));
        }

        [Test]
        public void ChangeQuantity_On_Multiple_Elements_ShouldWorkCorrectly()
        {
            AddThreeProducts();

            stock.ChangeQuantity(product1.Label, 50);
            stock.ChangeQuantity(product2.Label, 50);
            stock.ChangeQuantity(product3.Label, 50);

            var expected = new List<IProduct>() { product1, product2, product3 };
            var actual = stock.FindAllByQuantity(50).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByLabel_Should_Work_Correctly()
        {
            AddThreeProducts();

            stock.ChangeQuantity("Water", 3);

            Assert.IsTrue(stock.Contains(product1));
            Assert.AreSame(product2, stock.FindByLabel("Laptop")
                , "FindByLabel on existing element should return the element itself");
        }

        [Test]
        public void FindByLabel_NoExistingProduct_ShouldThrow()
        {
            AddThreeProducts();

            Assert.Throws<ArgumentException>(() => stock.FindByLabel("Non existant"));
        }

        [Test]
        public void FindAllByPriceRange_On_NonExistingRange_ShouldReturnEmpty_Enumeration()
        {
            AddThreeProducts();

            var actual = stock.FindAllInRange(0.55m, 0.69m).ToList();
            CollectionAssert.AreEqual(new List<IProduct>(), actual);
        }

        [Test]
        public void FindAllByPriceRange_On_ExistingRange_ShouldReturn_Correct_Enumeration()
        {
            AddSevenProducts();
            var expected = new List<IProduct>() { product2, product6 };

            var actual = stock.FindAllInRange(140, 210m).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindAllByPriceRange_LowerEndExclusive_HigherEndInclusive_ShouldWorkCorrectly()
        {
            AddSevenProducts();
            var expected = new List<IProduct>() { product5 };

            var actual = stock.FindAllInRange(19.0m, 25.0m).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByPrice_On_ExistingItems_ShouldReturn_Correct_Enumeration()
        {
            AddSevenProducts();
            var expected = new List<IProduct>() { product1, product7};

            var actual = stock.FindAllByPrice(0.50m).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByPrice_On_Non_ExistantPrice_ShouldReturn_Empty_Enumeration()
        {
            AddSevenProducts();

            //Assert
            var actual = stock.FindAllByPrice(0.70m).ToList();
            CollectionAssert.AreEqual(new List<IProduct>(), actual);
        }

        [Test]
        public void FindByPrice_UnderFloatingPoint_PrecisionSurcumstances_ShouldNotFail()
        {
            AddThreeProducts();

            var actual = stock.FindAllByPrice(1.2999999m).ToList();
            CollectionAssert.AreEqual(new List<IProduct>(), actual);
        }

        [Test]
        public void FindAllByQuantity_Should_Return_Correct_Enumeration()
        {
            AddSevenProducts();

            var expected = new List<IProduct>() { product4, product5};
            var actual = stock.FindAllByQuantity(10).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindAllByQuantity_Should_Return_EmptyEnumeration_After_Change_Qty()
        {
            AddSevenProducts();

            var expected = new List<IProduct>() { product1 };
            var actualBefore = stock.FindAllByQuantity(50).ToList();
            CollectionAssert.AreEqual(expected, actualBefore);

            stock.ChangeQuantity("Water", 5);

            var actual = stock.FindAllByQuantity(50).ToList();
            CollectionAssert.AreEqual(new List<IProduct>(), actual);
        }

        [Test]
        public void FindAllByQuantity_On_WrongArgument_ShouldReturnEmpty_Enumeration()
        {
            AddSevenProducts();

            stock.ChangeQuantity("Charger", 5);
            stock.ChangeQuantity("Screen", 5);
            stock.ChangeQuantity("Mouse", 5);

            var expected = new List<IProduct>();
            var actual = stock.FindAllByQuantity(500).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Enumerator_ShouldReturn_ProductsInInsertionOrder_After_Adding_Multiple()
        {
            AddSevenProducts();

            var expected = new List<Product>()
            {
                product1,product2,
                product3, product4,
                product5, product6,
                product7,
            };

            var actual = stock.Take(stock.Count).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Enumerator_ShouldReturn_EmptyEnumeration_On_Empty_Stock()
        {
            var expected = new List<IProduct>();
            var actual = stock.Take(stock.Count).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        private void AddSevenProducts()
        {
            this.stock.Add(this.product1);
            this.stock.Add(this.product2);
            this.stock.Add(this.product3);
            this.stock.Add(this.product4);
            this.stock.Add(this.product5);
            this.stock.Add(this.product6);
            this.stock.Add(this.product7);
        }

        private void AddThreeProducts()
        {
            this.stock.Add(this.product1);
            this.stock.Add(this.product2);
            this.stock.Add(this.product3);
        }

    }
}