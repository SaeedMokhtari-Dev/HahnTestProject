﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Data.Helpers;
using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.HTTPClients;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;
using Hahn.ApplicationProcess.December2020.Domain.Validators.EmployeeValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Hahn.ApplicationProcess.December2020.Domain.Businesses
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly RestCountryClient _restCountryClient;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper, RestCountryClient restCountryClient)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _restCountryClient = restCountryClient;
        }
        
        public async Task<EmployeeGet> Add(EmployeeAdd employeeAdd)
        {
            EmployeeAddValidator employeeAddValidator = new EmployeeAddValidator(_restCountryClient);

            ValidationResult results = await employeeAddValidator.ValidateAsync(employeeAdd);

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
                Employee employee = await _employeeRepository.Add(_mapper.Map<Employee>(employeeAdd));
                return _mapper.Map<EmployeeGet>(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeGet> Update(EmployeeUpdate employeeUpdate)
        {
            EmployeeUpdateValidator employeeUpdateValidator = new EmployeeUpdateValidator(_restCountryClient);

            ValidationResult results = await employeeUpdateValidator.ValidateAsync(employeeUpdate);

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
                Employee employee = await _employeeRepository.Update(_mapper.Map<Employee>(employeeUpdate));
                return _mapper.Map<EmployeeGet>(employee);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task Delete(EmployeeDelete employeeDelete)
        {
            EmployeeDeleteValidator employeeDeleteValidator = new EmployeeDeleteValidator();

            ValidationResult results = await employeeDeleteValidator.ValidateAsync(employeeDelete);

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
                await _employeeRepository.Delete(_mapper.Map<Employee>(employeeDelete));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<EmployeeGet> GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be null or empty");

            Employee employee = await _employeeRepository.GetById(id);
            if (employee == null)
                throw new Exception("Employee with this id not found");
            return _mapper.Map<EmployeeGet>(employee);
        }

        public async Task<List<EmployeeGet>> GetAll()
        {
            List<Employee> people = await _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeGet>>(people);
        }
    }
}