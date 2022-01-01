using System;
using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.CompanyDtos;

namespace Services.AutoMapper.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>();
            CreateMap<CompanyUpdateDto, Company>().ForMember(a => a.ModifiedDate, x => x.MapFrom(x => DateTime.Now));
        }
    }
}

