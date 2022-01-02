using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserLuckyProduct : IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}