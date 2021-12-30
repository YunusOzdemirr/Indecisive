using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Picture:EntityBase<int>,IEntity
    {
        public int ObjectId { get; set; }
        public object Object{ get; set; }
        public byte[] File{ get; set; }
    }
}

