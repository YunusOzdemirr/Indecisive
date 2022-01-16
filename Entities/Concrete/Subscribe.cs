using System.Reflection.PortableExecutable;
using Entities.ComplexTypes;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Subscribe : EntityBase<int>, IEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public int SubscribeTypeId { get; set; }
        public SubscribeType? SubscribeType { get; set; }
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}