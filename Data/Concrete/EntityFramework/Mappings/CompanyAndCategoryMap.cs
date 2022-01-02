using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CompanyAndCategoryMap : IEntityTypeConfiguration<CompanyAndCategory>
    {
        public void Configure(EntityTypeBuilder<CompanyAndCategory> builder)
        {
            builder.HasKey(a => new { a.CategoryId, a.CompanyId });
            builder.Property(a => a.CompanyId).IsRequired();
            builder.Property(a => a.CategoryId).IsRequired();
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.CompanyAndCategories).HasForeignKey(a => a.CompanyId);
            builder.HasOne<Category>(a => a.Category).WithMany(a => a.CompanyAndCategories).HasForeignKey(a => a.CategoryId);
            builder.ToTable("CompanyAndCategories");
        }
    }
}