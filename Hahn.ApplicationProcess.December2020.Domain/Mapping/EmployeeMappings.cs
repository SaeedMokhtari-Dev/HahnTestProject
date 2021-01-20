using System;
using AutoMapper;
using AutoMapper.Configuration;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Mapping
{
    public class EmployeeMappings: Profile
    {
        public EmployeeMappings()
        {
            CreateMap<Employee, EmployeeAdd>();
            CreateMap<Employee, EmployeeUpdate>();
            CreateMap<Employee, EmployeeDelete>();
            CreateMap<EmployeeGet, Employee>();
        }
    }
}