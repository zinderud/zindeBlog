using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;

namespace ZindeBlog.Web.Infrastructure.Repositories.Abstract
{
    

    public interface ILoggingRepository : IEntityBaseRepository<Error> { }

   

    public interface IRoleRepository : IEntityBaseRepository<Role> { }

    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }
}
