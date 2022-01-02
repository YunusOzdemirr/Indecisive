using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(a => new { a.UserId, a.RoleId });
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.RoleId).IsRequired();
            builder.HasOne<User>(a => a.User).WithMany(a => a.UserRoles).HasForeignKey(a => a.UserId);
            builder.HasOne<Role>(a => a.Role).WithMany(a => a.UserRoles).HasForeignKey(a => a.RoleId);
            builder.ToTable("UserRoles");
        }
    }
}