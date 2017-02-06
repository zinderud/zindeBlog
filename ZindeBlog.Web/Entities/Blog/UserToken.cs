using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities.Blog
{
    public class UserToken
    {
        public string Token { get; set; }

        public int UserID { get; set; }
    }
}
