using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ZindeBlog.Web.Infrastructure;

namespace ZindeBlog.Web.Migrations
{
    [DbContext(typeof(ZindeBlogContext))]
    partial class ZindeBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.CategoryTopic", b =>
                {
                    b.Property<int>("CategoryID");

                    b.Property<int>("TopicID");

                    b.HasKey("CategoryID", "TopicID");

                    b.HasIndex("TopicID");

                    b.ToTable("CategoryTopic");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateIP")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<bool>("NotifyOnComment");

                    b.Property<int?>("ReplyToID");

                    b.Property<byte>("Status");

                    b.Property<int>("TopicID");

                    b.Property<int?>("UserID");

                    b.Property<string>("WebSite")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Page", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime>("EditDate");

                    b.Property<bool>("IsHomePage");

                    b.Property<string>("Keywords")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Order");

                    b.Property<int?>("ParentID");

                    b.Property<bool>("ShowInList");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("Page");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Setting", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Key");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.HasIndex("Keyword")
                        .IsUnique();

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.TagTopic", b =>
                {
                    b.Property<int>("TagID");

                    b.Property<int>("TopicID");

                    b.HasKey("TagID", "TopicID");

                    b.HasIndex("TopicID");

                    b.ToTable("TagTopic");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("AllowComment");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("CreateUserID");

                    b.Property<DateTime>("EditDate");

                    b.Property<int>("EditUserID");

                    b.Property<byte>("Status");

                    b.Property<string>("Summary")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.UserToken", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("UserID");

                    b.HasKey("Token");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.Widget", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Config")
                        .IsRequired();

                    b.Property<byte>("Type");

                    b.HasKey("ID");

                    b.ToTable("Widget");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.CategoryTopic", b =>
                {
                    b.HasOne("ZindeBlog.Web.Entities.Blog.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZindeBlog.Web.Entities.Blog.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.Blog.TagTopic", b =>
                {
                    b.HasOne("ZindeBlog.Web.Entities.Blog.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZindeBlog.Web.Entities.Blog.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZindeBlog.Web.Entities.UserRole", b =>
                {
                    b.HasOne("ZindeBlog.Web.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZindeBlog.Web.Entities.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
