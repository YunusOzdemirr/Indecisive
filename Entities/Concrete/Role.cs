using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Role:EntityBase<int>,IEntity
    {
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

