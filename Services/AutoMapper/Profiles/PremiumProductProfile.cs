using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.PremiumProductDtos;

namespace Services.AutoMapper.Profiles
{
    public class PremiumProductProfile : Profile
    {
        public PremiumProductProfile()
        {
            CreateMap<PremiumProductAddDto, PremiumProduct>();
            CreateMap<PremiumProductUpdateDto, PremiumProduct>();//.ForMember(a => a.ModifiedDate, x => x.MapFrom(x => DateTime.Now));
        }
    }
}