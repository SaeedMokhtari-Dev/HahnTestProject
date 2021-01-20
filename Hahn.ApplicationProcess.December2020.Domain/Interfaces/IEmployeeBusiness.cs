using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Interfaces
{
    public interface IEmployeeBusiness: IBusiness
    {
        Task<EmployeeGet> Add(EmployeeAdd employee);
        Task<EmployeeGet> Update(EmployeeUpdate employee);
        Task Delete(EmployeeDelete employee);
        Task<EmployeeGet> GetById(int id);
        Task<List<EmployeeGet>> GetAll();
    }
}