using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Enums;

namespace ZindeBlog.Web.ViewModels.Widget
{
    public class WidgetModel
    {
        public WidgetType Type { get; set; }

        public WidgetConfigModelBase Config { get; set; }
    }
}
