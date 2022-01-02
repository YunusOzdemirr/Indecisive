using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserAndProduct : IEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}