using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Description).HasMaxLength(250);
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.Categories).HasForeignKey(a => a.CompanyId);
            //builder.HasOne<Product>(a => a.Product).WithMany(a => a.Categories).HasForeignKey(a => a.ProductId);
            builder.HasOne<User>(a => a.User).WithMany(a => a.FavCategories).HasForeignKey(a => a.UserId);
            builder.ToTable("Categories");
        }
    }
}

