using Andreys.Services;
using Andreys.ViewModels.Products;

using SUS.HTTP;
using SUS.MvcFramework;

using System;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Error("Name is required and should be between 4 and 20 characters long.");
            }

            if (!Uri.TryCreate(model.ImageUrl, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (model.Price < 0)
            {
                return this.Error("Price cannot be negative.");
            }

            if (model.Description.Length > 10)
            {
                return this.Error("Description length should be 10 characters at most.");
            }

            this.productsService.AddProduct(model);
            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var product = this.productsService.GetDetails(id);
            return this.View(product);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.productsService.DeleteById(id);

            return this.Redirect("/");
        }
    }
}
