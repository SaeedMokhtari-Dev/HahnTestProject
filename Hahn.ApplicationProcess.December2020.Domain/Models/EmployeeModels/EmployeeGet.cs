using System;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels
{
    public class EmployeeGet: EmployeeModel, IExamplesProvider<EmployeeGet>
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }
        public new EmployeeGet GetExamples()
        {
            return new()
            {
                Id = 1,
                Name = "Saeed",
                FamilyName = "Mokhtari",
                Address = "413 South Brickyard Ave.Flushing, NY 11354",
                Age = 25,
                Hired = true,
                CountryOfOrigin = "IR",
                EMailAddress = "saeedmokhtari.dev@gmail.com",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };
        }
    }
}