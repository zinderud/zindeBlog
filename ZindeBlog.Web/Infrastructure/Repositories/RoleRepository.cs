using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Infrastructure.Repositories.Abstract;

namespace ZindeBlog.Web.Infrastructure.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ZindeBlogContext context)
            : base(context)
        { }
    }
}
