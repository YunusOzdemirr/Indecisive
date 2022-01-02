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
        public byte[]? Picture { get; set; }
        public int? PremiumProductCount { get; set; }
        public int? ProductCount { get; set; }
        public ICollection<CompanyAndProduct> CompanyAndProducts { get; set; }
        public ICollection<CompanyAndCategory> CompanyAndCategories { get; set; }
        public ICollection<CompanyAndRole> CompanyAndRoles { get; set; }
        public ICollection<PremiumProduct> PremiumProducts { get; set; }
    }
}

