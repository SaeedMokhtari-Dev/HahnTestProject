using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Data.Helpers;
using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels;
using Hahn.ApplicationProcess.December2020.Domain.Validators.PersonValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Hahn.ApplicationProcess.December2020.Domain.Businesses
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonBusiness(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        
        public async Task<PersonGet> Add(PersonAdd personAdd)
        {
            PersonAddValidator personAddValidator = new PersonAddValidator();

            ValidationResult results = await personAddValidator.ValidateAsync(personAdd);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }

            Person person = await _personRepository.Add(_mapper.Map<Person>(personAdd));
            return _mapper.Map<PersonGet>(person);
        }

        public async Task<PersonGet> Update(PersonUpdate personUpdate)
        {
            PersonUpdateValidator personUpdateValidator = new PersonUpdateValidator();

            ValidationResult results = await personUpdateValidator.ValidateAsync(personUpdate);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }

            Person person = await _personRepository.Update(_mapper.Map<Person>(personUpdate));
            return _mapper.Map<PersonGet>(person);
        }

        public async Task Delete(PersonDelete personDelete)
        {
            PersonDeleteValidator personDeleteValidator = new PersonDeleteValidator();

            ValidationResult results = await personDeleteValidator.ValidateAsync(personDelete);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                        failure.ErrorMessage);
                }
            }

            await _personRepository.Delete(_mapper.Map<Person>(personDelete));
        }

        public async Task<PersonGet> GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be null or empty");

            Person person = await _personRepository.GetById(id);
            return _mapper.Map<PersonGet>(person);
        }

        public async Task<List<PersonGet>> GetAll()
        {
            List<Person> people = await _personRepository.GetAll();
            return _mapper.Map<List<PersonGet>>(people);
        }
    }
}