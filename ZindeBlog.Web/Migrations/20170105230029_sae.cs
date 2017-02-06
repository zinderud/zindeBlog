using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZindeBlog.Web.Migrations
{
    public partial class sae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateIP = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    NotifyOnComment = table.Column<bool>(nullable: false),
                    ReplyToID = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    TopicID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
                    WebSite = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(maxLength: 100, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    EditDate = table.Column<DateTime>(nullable: false),
                    IsHomePage = table.Column<bool>(nullable: false),
                    Keywords = table.Column<string>(maxLength: 100, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentID = table.Column<int>(nullable: true),
                    ShowInList = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Keyword = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(maxLength: 100, nullable: true),
                    AllowComment = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserID = table.Column<int>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    EditUserID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Summary = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Token = table.Column<string>(maxLength: 32, nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Config = table.Column<string>(nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Avatar = table.Column<string>(maxLength: 100, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    HashedPassword = table.Column<string>(maxLength: 200, nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Nickname = table.Column<string>(maxLength: 20, nullable: false),
                    Salt = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTopic",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false),
                    TopicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTopic", x => new { x.CategoryID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_CategoryTopic_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTopic_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagTopic",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false),
                    TopicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTopic", x => new { x.TagID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_TagTopic_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTopic_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTopic_TopicID",
                table: "CategoryTopic",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Alias",
                table: "Page",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Keyword",
                table: "Tag",
                column: "Keyword",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagTopic_TopicID",
                table: "TagTopic",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_Alias",
                table: "Topic",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTopic");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "TagTopic");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Widget");

            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
