using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CompanyAndProductMap : IEntityTypeConfiguration<CompanyAndProduct>
    {
        public void Configure(EntityTypeBuilder<CompanyAndProduct> builder)
        {
            builder.HasKey(a => new { a.CompanyId, a.ProductId });
            builder.Property(a => a.CompanyId).IsRequired();
            builder.Property(a => a.ProductId).IsRequired();
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.CompanyAndProducts).HasForeignKey(a => a.ProductId);
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.CompanyAndProducts).HasForeignKey(a => a.CompanyId);
        }
    }
}