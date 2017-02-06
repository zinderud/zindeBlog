using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities.Blog
{
    public class TagTopic
    {
        public int TagID { get; set; }

        public int TopicID { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
