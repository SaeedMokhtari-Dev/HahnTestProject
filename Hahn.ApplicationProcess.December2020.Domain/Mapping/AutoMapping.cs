using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels;

namespace Hahn.ApplicationProcess.December2020.Domain.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicantAdd, Applicant>().ReverseMap();
            CreateMap<ApplicantUpdate, Applicant>().ReverseMap();
            CreateMap<ApplicantDelete, Applicant>().ReverseMap();
            CreateMap<Applicant, ApplicantGet>().ReverseMap();
        }
    }
}