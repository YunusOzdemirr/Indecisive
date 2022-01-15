using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Role : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<CompanyAndRole> CompanyAndRoles { get; set; }
    }
}
