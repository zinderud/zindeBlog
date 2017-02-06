using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Infrastructure.Enums
{
    public enum CommentStatus : byte
    {
        Pending = 0,

        Approved = 1,

        Reject = 2,

        Junk = 255
    }
}
