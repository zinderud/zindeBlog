using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using Microsoft.EntityFrameworkCore;
using ZindeBlog.Web.Entities.Blog;

namespace ZindeBlog.Web.Infrastructure.Data.Mappings
{
    public sealed class WidgetMapping
    {
        public static void Map(EntityTypeBuilder<Widget> builder)
        {
            builder.ToTable("Widget");

            builder.HasKey(t => new { t.ID });

            builder.Property(t => t.Config).IsRequired();
        }
    }
}
