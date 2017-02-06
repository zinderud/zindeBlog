using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;

namespace ZindeBlog.Web.Infrastructure.Core
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
