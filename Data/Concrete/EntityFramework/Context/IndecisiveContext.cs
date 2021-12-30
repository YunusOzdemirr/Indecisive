using System;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Context
{
    public class IndecisiveContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=Indecisive;User=sa;Password=Password123@jkl#;");
        }
    }
}

