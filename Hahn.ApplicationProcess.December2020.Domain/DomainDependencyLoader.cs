using AutoMapper;
using Hahn.ApplicationProcess.December2020.Domain.Businesses;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Domain
{
    public static class DomainDependencyLoader
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}