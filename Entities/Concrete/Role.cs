using System;
namespace Entities.Concrete
{
    public class Role
    {
        public string Name { get; set; }
        public int? UserId{ get; set; }
        public User? User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

