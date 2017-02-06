using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;

namespace ZindeBlog.Web.Infrastructure.Data.Mappings
{
    public static class RoleMapping
    {
        public static void Map(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
             
        }
    }
}
