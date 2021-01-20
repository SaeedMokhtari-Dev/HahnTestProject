using System;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels
{
    public class EmployeeGet: EmployeeModel
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}