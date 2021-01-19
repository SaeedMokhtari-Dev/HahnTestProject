using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces
{
    public interface IPersonRepository: IRepository
    {
        Task<Person> Add(Person person);
        Task<Person> Update(Person person);
        Task Delete(Person person);
        Task<Person> GetById(int id);
        Task<List<Person>> GetAll();
    }
}