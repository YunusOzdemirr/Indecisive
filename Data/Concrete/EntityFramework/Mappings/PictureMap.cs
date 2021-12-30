﻿using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class PictureMap : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.File).IsRequired();
            builder.HasOne<User>(a => a.User).WithMany(a => a.Pictures).HasForeignKey(a => a.UserId);
        }
    }
}

