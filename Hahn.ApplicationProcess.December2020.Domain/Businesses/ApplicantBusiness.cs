using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.HTTPClients;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels;
using Hahn.ApplicationProcess.December2020.Domain.Validators.ApplicantValidators;

namespace Hahn.ApplicationProcess.December2020.Domain.Businesses
{
    public class ApplicantBusiness : IApplicantBusiness
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        private readonly RestCountryClient _restCountryClient;
        public ApplicantBusiness(IApplicantRepository applicantRepository, IMapper mapper, RestCountryClient restCountryClient)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _restCountryClient = restCountryClient;
        }
        
        public async Task<ApplicantGet> Add(ApplicantAdd applicantAdd)
        {
            ApplicantAddValidator applicantAddValidator = new ApplicantAddValidator(_restCountryClient);

            ValidationResult results = await applicantAddValidator.ValidateAsync(applicantAdd);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }
            
            try
            {
                Applicant applicant = await _applicantRepository.Add(_mapper.Map<Applicant>(applicantAdd));
                return _mapper.Map<ApplicantGet>(applicant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicantGet> Update(ApplicantUpdate applicantUpdate)
        {
            ApplicantUpdateValidator applicantUpdateValidator = new ApplicantUpdateValidator(_restCountryClient);

            ValidationResult results = await applicantUpdateValidator.ValidateAsync(applicantUpdate);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }

            try
            {
                Applicant applicant = await _applicantRepository.Update(_mapper.Map<Applicant>(applicantUpdate));
                return _mapper.Map<ApplicantGet>(applicant);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task Delete(ApplicantDelete applicantDelete)
        {
            ApplicantDeleteValidator applicantDeleteValidator = new ApplicantDeleteValidator();

            ValidationResult results = await applicantDeleteValidator.ValidateAsync(applicantDelete);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }

            try
            {
                await _applicantRepository.Delete(_mapper.Map<Applicant>(applicantDelete));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<ApplicantGet> GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be null or empty");

            Applicant applicant = await _applicantRepository.GetById(id);
            if (applicant == null)
                throw new Exception("Applicant with this id not found");
            return _mapper.Map<ApplicantGet>(applicant);
        }

        public async Task<List<ApplicantGet>> GetAll()
        {
            List<Applicant> people = await _applicantRepository.GetAll();
            return _mapper.Map<List<ApplicantGet>>(people);
        }
    }
}