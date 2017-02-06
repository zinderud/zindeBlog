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
    public static class TagMapping
    {
        public static void Map(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasIndex(t => t.Keyword).IsUnique();

            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Property(t => t.Keyword).IsRequired().HasMaxLength(100);
        }
    }
}
