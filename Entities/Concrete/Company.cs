using System;
using Entities.ComplexTypes;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Company : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public CompanyType CompanyType { get; set; }
        public int PremiumProductCount { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Role>? Roles { get; set; }
        public ICollection<PremiumProduct>? PremiumProducts{ get; set; }
    }
}

