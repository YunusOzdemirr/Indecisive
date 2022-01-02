using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CompanyAndRoleMap : IEntityTypeConfiguration<CompanyAndRole>
    {
        public void Configure(EntityTypeBuilder<CompanyAndRole> builder)
        {
            builder.HasKey(a => new { a.CompanyId, a.RoleId });
            builder.Property(a => a.CompanyId).IsRequired();
            builder.Property(a => a.RoleId).IsRequired();
            builder.HasOne<Company>(a => a.Company).WithMany(a => a.CompanyAndRoles).HasForeignKey(a => a.CompanyId);
            builder.HasOne<Role>(a => a.Role).WithMany(a => a.CompanyAndRoles).HasForeignKey(a => a.RoleId);
            builder.ToTable("CompanyAndRoles");
        }
    }
}