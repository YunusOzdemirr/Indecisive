using Entities.Concrete;

namespace Entities.Dtos.SubscribeDtos
{
    public class SubscribeAddDto
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CancelDate { get; set; }
        public SubscribeType? SubscribeType { get; set; }
        public int UserId { get; set; }
    }
}