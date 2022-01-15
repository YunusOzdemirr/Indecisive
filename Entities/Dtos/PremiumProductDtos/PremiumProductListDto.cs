using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.PremiumProductDtos
{
    public class PremiumProductListDto : DtoGetBase
    {
        public IEnumerable<PremiumProduct> PremiumProducts { get; set; }


    }
}