using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Infrastructure.Repositories.Abstract;

namespace ZindeBlog.Web.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        IRoleRepository _roleReposistory;
        public UserRepository(ZindeBlogContext context, IRoleRepository roleReposistory)
            : base(context)
        {
            _roleReposistory = roleReposistory;
        }

        public User GetSingleByUsername(string username)
        {
            return this.GetSingle(x => x.UserName == username);
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> _roles = null;

            User _user = this.GetSingle(u => u.UserName == username, u => u.UserRoles);
            if (_user != null)
            {
                _roles = new List<Role>();
                foreach (var _userRole in _user.UserRoles)
                    _roles.Add(_roleReposistory.GetSingle(_userRole.RoleId));
            }

            return _roles;
        }
    }
}
