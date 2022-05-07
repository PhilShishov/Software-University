
namespace INStock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using INStock.Contracts;

    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        private SortedDictionary<string, IProduct> byLabel;
        Dictionary<int, HashSet<IProduct>> byQuantity;

        public ProductStock()
        {
            this.products = new List<IProduct>();
            this.byLabel = new SortedDictionary<string, IProduct>();
            this.byQuantity = new Dictionary<int, HashSet<IProduct>>();
        }

        public int Count => products.Count;
        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return products[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }

                products.Insert(index, value);
            }
        }

        public void Add(IProduct product)
        {
            if (products.Contains(product))
            {
                throw new InvalidOperationException();
            }

            products.Add(product);
            this.byLabel.Add(product.Label, product);
            AddByQuantity(product);
        }

        public void ChangeQuantity(string product, int quantity)
        {
            if (!this.byLabel.ContainsKey(product))
            {
                throw new ArgumentException();
            }

            var targetProduct = this.byLabel[product];
            this.byQuantity[targetProduct.Quantity].Remove(targetProduct);
            this.byLabel[product].Quantity = quantity;
            this.AddByQuantity(targetProduct);
        }

        public bool Contains(IProduct product)
        {
            return this.byLabel.ContainsKey(product.Label);
        }

        public bool Remove(IProduct product)
        {
            return products.Remove(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return products[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (!this.byLabel.ContainsKey(label))
            {
                throw new ArgumentException();
            }

            return this.byLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return products
                .OrderByDescending(p => p.Price)
                .First();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(p => p.Price == price);
        }       

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(p => p.Quantity == quantity);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddByQuantity(IProduct product)
        {
            if (!this.byQuantity.ContainsKey(product.Quantity))
            {
                this.byQuantity.Add(product.Quantity, new HashSet<IProduct>());
            }
            this.byQuantity[product.Quantity].Add(product);
        }
    }
}
