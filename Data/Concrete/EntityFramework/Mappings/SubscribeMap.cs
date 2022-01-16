using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class SubscribeMap : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.ExpireDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.ToTable("Subscribes");
        }
    }
}