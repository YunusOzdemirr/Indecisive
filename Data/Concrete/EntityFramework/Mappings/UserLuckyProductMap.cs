using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class UserLuckyProductMap : IEntityTypeConfiguration<UserLuckyProduct>
    {
        public void Configure(EntityTypeBuilder<UserLuckyProduct> builder)
        {
            builder.HasKey(a => new { a.UserId, a.ProductId });
            builder.Property(a => a.ProductId).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.UserLuckyProducts).HasForeignKey(a => a.ProductId);
            builder.HasOne<User>(a => a.User).WithMany(a => a.UserLuckyProducts).HasForeignKey(a => a.UserId);
            builder.ToTable("UserLuckyProducts");
        }
    }
}