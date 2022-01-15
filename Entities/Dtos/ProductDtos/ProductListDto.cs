using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.ProductDtos
{
    public class ProductListDto : DtoGetBase
    {
        public ICollection<Product> Products { get; set; }
    }
}