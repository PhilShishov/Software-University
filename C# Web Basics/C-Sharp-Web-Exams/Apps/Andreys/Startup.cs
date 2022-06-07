namespace Andreys
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Andreys.Services;
    using Andreys.Data;

    using SUS.MvcFramework;
    using SUS.HTTP;

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
