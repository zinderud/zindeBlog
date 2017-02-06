using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.ViewModels.Topic;

namespace ZindeBlog.Web.ViewModels.Tag
{
    public class TagModel
    {
        public int ID { get; set; }

        public string Keyword { get; set; }

        public TopicCountModel Topics { get; set; }
    }
}
