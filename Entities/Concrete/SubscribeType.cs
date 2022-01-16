using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class SubscribeType : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
    }
}