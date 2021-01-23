using Hahn.ApplicationProcess.December2020.Domain.Configs;
using Hahn.ApplicationProcess.December2020.Domain.HTTPClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Helpers
{
    public static class HttpClientHelper
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            var restCountriesAPIsSection = configuration.GetSection("RestCountriesAPIs");
            services.Configure<RestCountriesAPIs>(restCountriesAPIsSection);

            services.AddHttpClient<RestCountryClient>();
        }
    }
}