using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.ViewModels.Category;

namespace ZindeBlog.Web.ViewModels.Topic
{
    public class TopicModel : TopicBasicModel, ITopicModel
    {
        public string Summary { get; set; }

        public string Content { get; set; }

        public CategoryBasicModel[] Categories { get; set; }

        public string[] Tags { get; set; }

        public DateTime Date { get; set; }

        public bool AllowComment { get; set; }

        public Infrastructure.Enums.TopicStatus Status { get; set; }
    }
}
