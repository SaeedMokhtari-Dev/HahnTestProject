namespace Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels
{
    public class EmployeeDelete
    {
        public EmployeeDelete(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}