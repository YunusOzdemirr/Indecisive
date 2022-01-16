using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.FirstName).HasMaxLength(30);
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(50);
            builder.Property(a => a.UserName).IsRequired();
            builder.Property(a => a.UserName).HasMaxLength(20);
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(100);
            builder.HasOne<Subscribe>(a => a.Subscribe).WithMany(a => a.Users).HasForeignKey(a => a.SubscribeId);
            builder.ToTable("Users");
        }
    }
}

