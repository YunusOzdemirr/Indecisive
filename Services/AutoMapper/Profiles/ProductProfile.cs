using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;

namespace Services.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductUpdateDto, Product>().ForMember(a => a.ModifiedDate, x => x.MapFrom(x => DateTime.Now));
        }
    }
}