using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Interfaces
{
    public interface IApplicantBusiness: IBusiness
    {
        Task<ApplicantGet> Add(ApplicantAdd applicant);
        Task<ApplicantGet> Update(ApplicantUpdate applicant);
        Task Delete(ApplicantDelete applicant);
        Task<ApplicantGet> GetById(int id);
        Task<List<ApplicantGet>> GetAll();
    }
}