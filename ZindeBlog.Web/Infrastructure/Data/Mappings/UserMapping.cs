using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZindeBlog.Web.Infrastructure.Data.Mappings
{
    public sealed class UserMapping
    {
        public static void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasIndex(t => t.UserName).IsUnique();

            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.HashedPassword).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Salt).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Nickname).HasMaxLength(20);
            builder.Property(t => t.Email).HasMaxLength(100);
            builder.Property(t => t.Avatar).HasMaxLength(100);
            builder.Property(t => t.IsLocked).IsRequired();



        }
    }
}
