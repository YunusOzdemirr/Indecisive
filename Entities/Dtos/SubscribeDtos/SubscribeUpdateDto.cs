using Entities.Concrete;

namespace Entities.Dtos.SubscribeDtos
{
    public class SubscribeUpdateDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CancelDate { get; set; }
        public SubscribeType SubscribeType { get; set; }
        public int UserId { get; set; }
    }
}