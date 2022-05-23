
namespace EmployeesMapping.App
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    using Employees.Data;
    using Employees.Services;
    using Employees.Services.Interfaces;

    using EmployeesMapping.App.Core;

    public class Launcher
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>();

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddAutoMapper(am => am.AddProfile<MappingProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
