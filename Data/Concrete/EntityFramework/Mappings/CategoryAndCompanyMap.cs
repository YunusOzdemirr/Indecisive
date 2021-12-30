using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CategoryAndCompanyMap:IEntityTypeConfiguration<CategoryAndCompany>
    {
        public void Configure(EntityTypeBuilder<CategoryAndCompany> builder)
        {
            builder.HasKey(cc => new { cc.CategoryId, cc.CompanyId });
            builder.HasOne<Category>(cc => cc.Category).WithMany(c => c.CategoryAndCompanies).HasForeignKey(cc => cc.CategoryId);
            builder.HasOne<Company>(cc => cc.Company).WithMany(co => co.CategoriesAndCompany).HasForeignKey(co => co.CompanyId);
            builder.ToTable("CategoriesAndCompanies");
        }
    }
}

