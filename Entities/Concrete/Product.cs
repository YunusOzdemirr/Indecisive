using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product:EntityBase<int>,IEntity
    {
        public string Name { get; set; }
        public int? CompanyId{ get; set; }
        public Company? Company { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public double PossibilityPercent { get; set; }

    }
}

