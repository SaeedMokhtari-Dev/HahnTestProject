using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository: IRepository
    {
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Delete(Employee employee);
        Task<Employee> GetById(int id);
        Task<List<Employee>> GetAll();
    }
}