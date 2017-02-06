using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Infrastructure.Enums
{
    public enum WidgetType : byte
    {
        Administration = 1,

        Category = 2,

        Tag = 3,

        RecentTopic = 4,

        RecentComment = 5,

        MonthStatistics = 6,

        Page = 7,

        Search = 8,

        Link = 9
    }
}
