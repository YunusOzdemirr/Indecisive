using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Picture:EntityBase<int>,IEntity
    {
        public int UserId { get; set; }
        public User User{ get; set; }
        public byte[] File{ get; set; }
    }
}

