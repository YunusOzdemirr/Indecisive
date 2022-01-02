using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class CategoryAndUser : IEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}