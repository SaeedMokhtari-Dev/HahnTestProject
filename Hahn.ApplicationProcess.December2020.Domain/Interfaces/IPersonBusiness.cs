using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Interfaces
{
    public interface IPersonBusiness: IBusiness
    {
        Task<PersonGet> Add(PersonAdd person);
        Task<PersonGet> Update(PersonUpdate person);
        Task Delete(PersonDelete person);
        Task<PersonGet> GetById(int id);
        Task<List<PersonGet>> GetAll();
    }
}