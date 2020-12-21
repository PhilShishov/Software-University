namespace Andreys
{
    using System.Collections.Generic;

    using Data;

    using SUS.MvcFramework;
    using SUS.HTTP;
    using Microsoft.EntityFrameworkCore;
    using Andreys.Services;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}
