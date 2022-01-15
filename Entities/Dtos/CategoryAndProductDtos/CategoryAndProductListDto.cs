using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.CategoryAndProductDtos
{
    public class CategoryAndProductListDto : DtoGetBase
    {
        public IEnumerable<CategoryAndProduct> CategoryAndProducts { get; set; }
    }
}