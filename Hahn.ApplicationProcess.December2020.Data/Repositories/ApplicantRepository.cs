using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories
{
    public class ApplicantRepository: IApplicantRepository
    {
        private readonly HahnContext _hahnContext;
        public ApplicantRepository(HahnContext hahnContext)
        {
            _hahnContext = hahnContext;
        }
        public async Task<Applicant> Add(Applicant applicant)
        {
            Applicant newApplicant = (await _hahnContext.Applicants.AddAsync(applicant)).Entity;
            await _hahnContext.SaveChangesAsync();
            return newApplicant;
        }

        public async Task<Applicant> Update(Applicant applicant)
        {
            Applicant editApplicant = _hahnContext.Applicants.Attach(applicant).Entity;
            await _hahnContext.SaveChangesAsync();
            return editApplicant;
        }

        public async Task Delete(Applicant applicant)
        {
            _hahnContext.Applicants.Remove(applicant);
            await _hahnContext.SaveChangesAsync();
        }

        public async Task<Applicant> GetById(int id)
        {
            if (id <= 0)
                throw new Exception($"invalid id value!");
            
            return await _hahnContext.Applicants.FindAsync(id);
        }

        public async Task<List<Applicant>> GetAll()
        {
            return await _hahnContext.Applicants.ToListAsync();
        }
    }
}