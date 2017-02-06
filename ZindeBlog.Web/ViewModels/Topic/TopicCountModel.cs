using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Topic
{
    public class TopicCountModel
    {
        public int Published { get; set; }

        public int Draft { get; set; }

        public int All { get; set; }
    }
}
