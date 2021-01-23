using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels
{
    public class ApplicantDelete: IModel, IExamplesProvider<ApplicantDelete>
    {
        public ApplicantDelete()
        {
            
        }
        public ApplicantDelete(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public ApplicantDelete GetExamples()
        {
            return new(1);
        }
    }
}