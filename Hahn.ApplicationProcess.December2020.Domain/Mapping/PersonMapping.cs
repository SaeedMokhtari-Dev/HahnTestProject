using System;
using AutoMapper;
using AutoMapper.Configuration;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Mapping
{
    public class PersonMappings: Profile
    {
        public PersonMappings()
        {
            CreateMap<Person, PersonAdd>();
            CreateMap<Person, PersonUpdate>();
            CreateMap<Person, PersonDelete>();
            CreateMap<PersonGet, Person>();
        }
    }
}