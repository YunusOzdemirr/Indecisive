using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.SubscribeDtos
{
    public class SubscribeListDto : DtoGetBase
    {
        public IEnumerable<Subscribe> Subscribes { get; set; }
    }
}