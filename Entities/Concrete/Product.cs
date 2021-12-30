using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProducts{ get; set; }

    }
}

