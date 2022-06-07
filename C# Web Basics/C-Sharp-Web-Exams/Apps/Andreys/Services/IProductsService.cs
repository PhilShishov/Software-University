

namespace Andreys.Services
{
    using System.Collections.Generic;

    using Andreys.Data;
    using Andreys.ViewModels.Products;

    public interface IProductsService
    {
        void AddProduct(AddProductInputModel input);

        IEnumerable<ProductViewModel> GetAll();

        Product GetDetails(int id);

        void DeleteById(int id);
    }
}
