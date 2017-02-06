using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Infrastructure.Enums
{
    public enum TopicStatus : byte
    {
        Draft = 0,
        Published = 1,
        Trash = 255
    }
}
