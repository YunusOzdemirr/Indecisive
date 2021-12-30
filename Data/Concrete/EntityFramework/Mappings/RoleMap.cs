using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.HasOne<User>(a => a.User).WithMany(a => a.Roles).HasForeignKey(a => a.UserId);
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.Roles).HasForeignKey(a => a.CompanyId);
            builder.ToTable("Roles");
        }
    }
}

