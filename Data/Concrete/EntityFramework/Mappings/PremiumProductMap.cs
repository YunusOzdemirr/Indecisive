using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class PremiumProductMap : IEntityTypeConfiguration<PremiumProduct>
    {
        public void Configure(EntityTypeBuilder<PremiumProduct> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Discount).IsRequired();
            builder.Property(a => a.Price).IsRequired();
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.PremiumProducts).HasForeignKey(a => a.CompanyId);
            builder.ToTable("PremiumProducts");
        }
    }
}

