

namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Andreys.Data;
    using Andreys.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext db;

        public ProductsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(AddProductInputModel input)
        {
            var genderAsEnum = Enum.Parse<Gender>(input.Gender);
            var categoryAsEnum = Enum.Parse<Category>(input.Category);

            var product = new Product
            {

                Description = input.Description,
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Price = input.Price,
                Category = categoryAsEnum,
                Gender = genderAsEnum,
            };
            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return this.db.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToList();
        }

        public Product GetDetails(int id)
        => this.db.Products.FirstOrDefault(x => x.Id == id);

        public void DeleteById(int id)
        {
            var product = this.GetDetails(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }
    }
}
