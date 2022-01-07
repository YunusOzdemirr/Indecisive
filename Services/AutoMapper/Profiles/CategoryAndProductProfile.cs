using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.CategoryAndProductDtos;

namespace Services.AutoMapper.Profiles
{
    public class CategoryAndProductProfile : Profile
    {
        public CategoryAndProductProfile()
        {
            CreateMap<CategoryAndProductAddDto, CategoryAndProduct>();
            CreateMap<CategoryAndProductUpdateDto, CategoryAndProduct>();
        }
    }
}