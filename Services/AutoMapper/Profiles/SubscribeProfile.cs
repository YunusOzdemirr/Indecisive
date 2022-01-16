using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.SubscribeDtos;

namespace Services.AutoMapper.Profiles
{
    public class SubscribeProfile : Profile
    {
        public SubscribeProfile()
        {
            CreateMap<SubscribeAddDto, Subscribe>();
            CreateMap<SubscribeUpdateDto, Subscribe>();
        }
    }
}