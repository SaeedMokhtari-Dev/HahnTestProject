using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Hahn.ApplicationProcess.December2020.Data.Repositories;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Data
{
    public static class DataDependencyLoader
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<HahnContext>(options =>
            {
                options.UseInMemoryDatabase("Hahn");
            });
        }
    }
}