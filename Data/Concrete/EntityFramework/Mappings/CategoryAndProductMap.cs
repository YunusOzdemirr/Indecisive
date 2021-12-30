using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CategoryAndProductMap : IEntityTypeConfiguration<CategoryAndProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryAndProduct> builder)
        {
            builder.HasKey(a => new { a.CategoryId, a.ProductId });
            builder.HasOne<Category>(ab => ab.Category).WithMany(a => a.CategoryAndProducts).HasForeignKey(ab=> ab.CategoryId);
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.CategoryAndProducts).HasForeignKey(a => a.ProductId);
            builder.ToTable("CategoriesAndProducts");
        }
    }
}

