using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZindeBlog.Web.Infrastructure.Data.Mappings
{
    public sealed class UserRoleMapping
    { 
    public static void Map(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");

         
        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId).IsRequired().HasMaxLength(20);
        builder.Property(t => t.RoleId).IsRequired().HasMaxLength(20);
       



    }
}
}
