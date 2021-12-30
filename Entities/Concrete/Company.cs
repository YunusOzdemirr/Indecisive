using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Company:EntityBase<int>,IEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products{ get; set; }
        public double PossibilityPercent { get; set; }
        public ICollection<CategoryAndCompany> CategoriesAndCompany{ get; set; }
    }
}

