using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserPicture : EntityBase<int>, IEntity
    {
        public byte[] File { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

