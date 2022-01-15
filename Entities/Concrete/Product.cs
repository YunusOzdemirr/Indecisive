using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public ICollection<CompanyAndProduct> CompanyAndProducts { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProducts { get; set; }
        public ICollection<UserAndProduct> UserAndProducts { get; set; }
        public ICollection<UserLuckyProduct> UserLuckyProducts { get; set; }
        public ICollection<PremiumProduct> PremiumProducts { get; set; }
    }
}

