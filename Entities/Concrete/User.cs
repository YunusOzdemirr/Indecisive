using Entities.ComplexTypes;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class User : EntityBase<int>, IEntity
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
        public int SubscribeId { get; set; }
        public Subscribe Subscribe { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserPicture> Pictures { get; set; }
        public ICollection<UserAndProduct> FavProducts { get; set; }
        public ICollection<UserLuckyProduct> UserLuckyProducts { get; set; }
        public ICollection<CategoryAndUser> FavCategory { get; set; }
    }
}