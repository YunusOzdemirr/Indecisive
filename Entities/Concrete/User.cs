using System;
using Entities.ComplexTypes;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class User:EntityBase<int>,IEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public byte PhoneNumer { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string About { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<Picture> Pictures{ get; set; }
        public IEnumerable<Product> FavProducts{ get; set; }
    }
}

