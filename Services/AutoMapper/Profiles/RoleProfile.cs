using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.RoleDtos;

namespace Services.AutoMapper.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleAddDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
        }
    }
}