using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class CompanyAndRole : IEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}