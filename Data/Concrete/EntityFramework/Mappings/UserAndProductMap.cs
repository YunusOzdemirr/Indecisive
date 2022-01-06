using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class UserAndProductMap : IEntityTypeConfiguration<UserAndProduct>
    {
        public void Configure(EntityTypeBuilder<UserAndProduct> builder)
        {
            builder.HasKey(a => new { a.UserId, a.ProductId });
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.ProductId).IsRequired();
            builder.HasOne<User>(a => a.User).WithMany(a => a.FavProducts).HasForeignKey(a => a.UserId);
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.UserAndProducts).HasForeignKey(a => a.ProductId);
            builder.ToTable("UserAndProducts");
        }
    }
}