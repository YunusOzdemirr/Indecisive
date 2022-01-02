using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(150);
            //builder.HasOne<Company>(a => a.Company).WithMany(a => a.Products).HasForeignKey(a => a.CompanyId);
            builder.HasOne<User>(a => a.User).WithMany(a => a.FavProducts).HasForeignKey(a => a.UserId);
            builder.ToTable("Products");
            //builder.HasOne<Company> bu kod hangi tip alabileceğini gösteriyor
            //(a=>a.Company)  Product içerisindeki Company den geliyor
            //WithMany birden fazla alabileceğini söylüyor bunu da Company Classının içerisinde alıyor
            //Forign Key olarakta Product içerisindeki CompanyId'yi veriyoruz.
        }
    }
}

