using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductPicture : EntityBase<int>, IEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public byte[] File { get; set; }
    }
}