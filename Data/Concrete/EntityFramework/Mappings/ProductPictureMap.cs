using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class ProductPictureMap : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.File).IsRequired();
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.ProductPictures).HasForeignKey(a => a.ProductId);
            builder.ToTable("ProductPictures");
        }
    }
}