using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels
{
    public class ApplicantModel: IModel, IExamplesProvider<ApplicantModel>
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }
        
        public string CountryOfOrigin { get; set; }

        public string EMailAddress  { get; set; }

        public int Age { get; set; }
        
        public bool Hired { get; set; }
        public ApplicantModel GetExamples()
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