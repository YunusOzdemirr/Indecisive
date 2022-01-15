using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public byte[]? Picture { get; set; }
        public string Description { get; set; }
        public double? PossibilityPercent { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProducts { get; set; }
        public ICollection<CompanyAndCategory> CompanyAndCategories { get; set; }
        public ICollection<CategoryAndUser> CategoryAndUsers { get; set; }
    }
}

