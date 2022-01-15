using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class PremiumProduct : ManyToManyBase, IEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

