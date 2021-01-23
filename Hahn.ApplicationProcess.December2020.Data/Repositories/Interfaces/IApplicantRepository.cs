using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces
{
    public interface IApplicantRepository: IRepository
    {
        Task<Applicant> Add(Applicant applicant);
        Task<Applicant> Update(Applicant applicant);
        Task Delete(Applicant applicant);
        Task<Applicant> GetById(int id);
        Task<List<Applicant>> GetAll();
    }
}