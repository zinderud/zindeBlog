using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;

namespace ZindeBlog.Web.Infrastructure
{
    public static class DbInitializer
    {
        private static ZindeBlogContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //context = (ZindeBlogContext)serviceProvider.GetService(typeof(ZindeBlogContext));


            context = (ZindeBlogContext)serviceProvider.GetService(typeof(ZindeBlogContext));
          
            
            InitializeUserRoles();

        }

     
        private static void InitializeUserRoles()
        {
            if (!context.Roles.Any())
            {
                // create roles
                context.Roles.AddRange(new Role[]
                {
                new Role()
                {
                    Name="Admin"
                }
                });
                context.Users.Add(new User()
                {
                    Email = "mokosam@gmail.com",
                    UserName = "sade",
                    HashedPassword = "9wsmLgYM5Gu4zA/BSpxK2GIBEWzqMPKs8wl2WDBzH/4=",
                    Salt = "GTtKxJA6xJuj3ifJtTXn9Q==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
           
                 
                context.UserRoles.AddRange(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // MuratOnur
                }
            });
                context.SaveChanges();
            }
        }
    }
}
