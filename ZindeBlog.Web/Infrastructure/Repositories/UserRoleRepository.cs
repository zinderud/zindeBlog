using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Infrastructure.Repositories.Abstract;

namespace ZindeBlog.Web.Infrastructure.Repositories
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ZindeBlogContext context)
            : base(context)
        { }
    }
}
