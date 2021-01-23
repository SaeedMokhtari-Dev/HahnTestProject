using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels
{
    public class ApplicantAdd : ApplicantModel, IExamplesProvider<ApplicantAdd>
    {
        public new ApplicantAdd GetExamples()
        {
            return new()
            {
                Name = "Saeed",
                FamilyName = "Mokhtari",
                Address = "413 South Brickyard Ave.Flushing, NY 11354",
                Age = 25,
                Hired = true,
                CountryOfOrigin = "IR",
                EMailAddress = "saeedmokhtari.dev@gmail.com"
            };
        }
    }
}