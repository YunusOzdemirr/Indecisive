using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Picture : EntityBase<int>, IEntity
    {
        public byte[] File { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

