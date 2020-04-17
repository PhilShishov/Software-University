namespace Andreys.Services
{
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;

    public interface IProductService
    {
        int Add(ProductAddInputModel productAddInputModel);

        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void DeleteById(int id);
    }
}