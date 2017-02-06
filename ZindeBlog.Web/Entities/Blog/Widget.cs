using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities.Blog
{
    public class Widget
    {
        public int ID { get; set; }

        public Infrastructure.Enums.WidgetType Type { get; set; }

        public string Config { get; set; }
    }
}
