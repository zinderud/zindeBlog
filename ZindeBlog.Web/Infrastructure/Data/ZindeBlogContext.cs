using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Entities.Blog;
using ZindeBlog.Web.Infrastructure.Data.Mappings;

namespace ZindeBlog.Web.Infrastructure
{
    public class ZindeBlogContext : DbContext
    {
      
       
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Error> Errors { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryTopic> CategoryTopics { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<TagTopic> TagTopics { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

       

        public virtual DbSet<UserToken> UserTokens { get; set; }

        public virtual DbSet<Page> Pages { get; set; }

        public virtual DbSet<Widget> Widgets { get; set; }


        //Todo provider olarak incele
        //BlogContextExtensions ta 
        //public IServiceProvider ServiceProvider { get; private set; }
        //public ZindeBlogContext(DbContextOptions<ZindeBlogContext> options, IServiceProvider serviceProvider)
        //    : base(options)
        //{
        //    ServiceProvider = serviceProvider;
        //}
        public ZindeBlogContext(DbContextOptions options) : base(options)
        {
 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
    




            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(CategoryMapping.Map);
            modelBuilder.Entity<CategoryTopic>(CategoryTopicMapping.Map);
            modelBuilder.Entity<Comment>(CommentMapping.Map);
            modelBuilder.Entity<Page>(PageMapping.Map);
            modelBuilder.Entity<Role>(RoleMapping.Map);
            modelBuilder.Entity<Setting>(SettingMapping.Map);
           
            modelBuilder.Entity<Topic>(TopicMapping.Map);
            modelBuilder.Entity<Tag>(TagMapping.Map);
            modelBuilder.Entity<TagTopic>(TagTopicMapping.Map);
           
            modelBuilder.Entity<User>(UserMapping.Map);
            modelBuilder.Entity<UserToken>(UserTokenMapping.Map);

          
            modelBuilder.Entity<Widget>(WidgetMapping.Map);


        }
    }
}
