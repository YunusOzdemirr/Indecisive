using System;
using Data.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Context
{
    public class IndecisiveContext : DbContext
    {
        public DbSet<CategoryAndProduct> CategoryAndProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PremiumProduct> PremiumProducts { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new UserPictureMap());
            modelBuilder.ApplyConfiguration(new ProductPictureMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CategoryAndProductMap());
            modelBuilder.ApplyConfiguration(new PremiumProductMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=Indecisive;User=sa;Password=Password123@jkl#;");
        }
    }
}

