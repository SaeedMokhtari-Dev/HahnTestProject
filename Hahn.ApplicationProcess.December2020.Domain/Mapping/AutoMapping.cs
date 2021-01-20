using System;
using AutoMapper;
using AutoMapper.Configuration;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<EmployeeAdd, Employee>().ReverseMap();
            CreateMap<EmployeeUpdate, Employee>().ReverseMap();
            CreateMap<EmployeeDelete, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeGet>().ReverseMap();
        }
    }
}