using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class PremiumProduct : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

