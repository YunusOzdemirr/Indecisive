using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CompanyMap:IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.ToTable("Companies");
            //builder.HasOne<Article>(c => c.Article).WithMany(a => a.Categories).HasForeignKey(c => c.ArticleId);
        }
    }
}

