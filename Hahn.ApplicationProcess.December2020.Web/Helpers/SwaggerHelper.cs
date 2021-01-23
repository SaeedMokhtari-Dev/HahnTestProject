using System;
using System.IO;
using System.Reflection;
using Hahn.ApplicationProcess.December2020.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Web.Helpers
{
    public static class SwaggerHelper
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hahn Test Project",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Saeed Mokhtari",
                        Email = "saeedmokhtari.dev@gmail.com"
                    }
                });
                
                c.ExampleFilters();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if(File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerExamplesFromAssemblyOf<IModel>();
            services.AddSwaggerExamplesFromAssemblyOf<ControllerBase>();
        }
    }
}