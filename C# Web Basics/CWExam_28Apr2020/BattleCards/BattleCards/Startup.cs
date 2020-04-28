namespace BattleCards
{
    using System.Collections.Generic;
    using BattleCards.Data;
    using BattleCards.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardService, CardService>();
        }
    }
}
