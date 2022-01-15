using System.Collections.Generic;
using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.RoleDtos
{
    public class RoleListDto : DtoGetBase
    {
        public IEnumerable<Role> Roles { get; set; }
    }
}