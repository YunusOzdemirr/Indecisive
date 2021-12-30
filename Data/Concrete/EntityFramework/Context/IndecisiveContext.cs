using System;
using Data.Concrete.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Context
{
    public class IndecisiveContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new PictureMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=Indecisive;User=sa;Password=Password123@jkl#;");
        }
    }
}

