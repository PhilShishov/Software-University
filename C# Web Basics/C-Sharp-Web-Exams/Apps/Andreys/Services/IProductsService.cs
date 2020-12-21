using Andreys.Data;
using Andreys.ViewModels.Products;

using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void AddProduct(AddProductInputModel input);

        IEnumerable<ProductViewModel> GetAll();

        Product GetDetails(int id);

        void DeleteById(int id);
    }
}
