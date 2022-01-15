using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class CategoryAndProduct : IEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

