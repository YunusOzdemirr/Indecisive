using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class CompanyAndCategory : IEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}