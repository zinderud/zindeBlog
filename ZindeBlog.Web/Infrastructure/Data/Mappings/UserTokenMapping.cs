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
    public sealed class UserTokenMapping
    {
        public static void Map(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserToken");

            builder.HasKey(t => t.Token);

            builder.Property(t => t.Token).HasMaxLength(32);
        }
    }
}
