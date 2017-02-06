using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.Infrastructure.Extensions;
using ZindeBlog.Web.Infrastructure.Services.Abstract;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class UserService
    {
        private ZindeBlogContext BlogContext { get; set; }
        private EncryptionService EncryptionService;
        public UserService(ZindeBlogContext blogContext, EncryptionService encryptionService)
        {
            BlogContext = blogContext;
            EncryptionService = encryptionService;
        }

        public async Task<OperationResult> ChangePassword(int id, string oldPassword, string newPassword)
        {
            User entity = await BlogContext.Users.SingleOrDefaultAsync(t => t.Id == id);
            string salt = entity.Salt;
            oldPassword = EncryptionService.EncryptPassword(oldPassword,salt);
            newPassword = EncryptionService.EncryptPassword(newPassword,salt);

           

            if (entity == null)
            {
                return OperationResult.Failure(" User ChangePassword Failure");
            }
            if (entity.HashedPassword != oldPassword)
            {
                return OperationResult.Failure("oldPassword Failure ");
            }

            entity.HashedPassword = newPassword;

            await BlogContext.SaveChangesAsync();

            BlogContext.RemoveUserCache();

            return new OperationResult();
        }

        public async Task<OperationResult> EditUserInfo(int id, string email, string nickname)
        {
            if (await BlogContext.Users.AnyAsync(t => t.Email == email && t.Id != id))
            {
                return OperationResult.Failure("EditUserInfo Failure");
            }

            var user = await BlogContext.Users.SingleOrDefaultAsync(t => t.Id == id);

            if (user == null)
            {
                return OperationResult.Failure("EditUserInfo Failure");
            }

            user.Email = email;
            user.Nickname = nickname;

            await BlogContext.SaveChangesAsync();

            BlogContext.RemoveUserCache();

            return new OperationResult();
        }
    }
}
