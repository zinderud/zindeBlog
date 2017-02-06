using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities.Blog
{
    public class CategoryTopic
    {
        public int CategoryID { get; set; }

        public int TopicID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
