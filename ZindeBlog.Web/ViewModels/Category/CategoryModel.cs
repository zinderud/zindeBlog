using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.ViewModels.Topic;

namespace ZindeBlog.Web.ViewModels.Category
{
    public class CategoryModel : CategoryBasicModel
    {
        public string Description { get; set; }

        public TopicCountModel Topics { get; set; }
    }
}
