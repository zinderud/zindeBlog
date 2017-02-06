using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Widget
{
    public class AvailableWidgetModel
    {
        public Infrastructure.Enums.WidgetType Type { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public WidgetConfigModelBase DefaultConfig { get; set; }
    }
}
