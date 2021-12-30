using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Company:EntityBase<int>,IEntity
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Category> Categories{ get; set; }
        public double PossibilityPercent { get; set; }

    }
}

