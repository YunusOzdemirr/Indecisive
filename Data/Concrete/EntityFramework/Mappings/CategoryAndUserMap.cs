using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CategoryAndUserMap : IEntityTypeConfiguration<CategoryAndUser>
    {
        public void Configure(EntityTypeBuilder<CategoryAndUser> builder)
        {
            builder.HasKey(a => new { a.UserId, a.CategoryId });
            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.HasOne<User>(a => a.User).WithMany(a => a.CategoryAndUsers).HasForeignKey(a => a.UserId);
            builder.HasOne<Category>(a => a.Category).WithMany(a => a.CategoryAndUsers).HasForeignKey(a => a.CategoryId);
            builder.ToTable("CategoryAndUsers");
        }
    }
}