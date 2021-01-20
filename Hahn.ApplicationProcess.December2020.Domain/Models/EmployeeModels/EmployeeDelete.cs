using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels
{
    public class EmployeeDelete: IModel, IExamplesProvider<EmployeeDelete>
    {
        public EmployeeDelete()
        {
            
        }
        public EmployeeDelete(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public EmployeeDelete GetExamples()
        {
            return new(1);
        }
    }
}