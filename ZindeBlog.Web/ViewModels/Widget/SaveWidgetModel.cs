using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Widget
{
    public class SaveWidgetModel
    {
        public Infrastructure.Enums.WidgetType Type { get; set; }

        [Required]
        public JObject Config { get; set; }
    }
}
