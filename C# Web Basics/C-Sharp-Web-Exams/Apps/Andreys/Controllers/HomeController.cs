namespace Andreys.Controllers
{
    using Andreys.Services;

    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var allProducts = this.productsService.GetAll();
                return this.View(allProducts, "Home");
            }

            return this.View();
        }
    }
}
