using System;
using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.CategoryDtos;

namespace Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, x => x.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.ModifiedDate, x => x.MapFrom(x => DateTime.Now));
        }
    }
}

