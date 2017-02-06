using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using Microsoft.EntityFrameworkCore;
using ZindeBlog.Web.Entities.Blog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZindeBlog.Web.Infrastructure.Data.Mappings
{
    public static class SettingMapping
    {
        public static void Map(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");

            builder.HasKey(t => t.Key);

            builder.Property(t => t.Key).HasMaxLength(50);
            builder.Property(t => t.Value).IsRequired();
        }
    }
}
