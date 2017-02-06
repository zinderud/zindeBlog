using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Widget
{
    public abstract class WidgetConfigModelBase
    {
        public string Title { get; set; }

        [JsonIgnore]
        public virtual bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Title);
            }
        }
    }

    public class AdministrationWidgetConfigModel : WidgetConfigModelBase
    {
        public AdministrationWidgetConfigModel()
        {
            this.Title = "Administration widget";
        }
    }

    public class CategoryWidgetConfigModel : WidgetConfigModelBase
    {
        public CategoryWidgetConfigModel()
        {
            this.Title = "CategoryWidget";
            this.ShowRSS = true;
            this.ShowNumbersOfTopics = true;
        }

        public bool ShowRSS { get; set; }

        public bool ShowNumbersOfTopics { get; set; }
    }

    public class RecentCommentWidgetConfigModel : WidgetConfigModelBase
    {
        public RecentCommentWidgetConfigModel()
        {
            this.Title = "RecentCommen";
            this.Number = 10;
        }

        public int Number { get; set; }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && this.Number > 0;
            }
        }
    }

    public class MonthStatisticeWidgetConfigModel : WidgetConfigModelBase
    {
        public MonthStatisticeWidgetConfigModel()
        {
            this.Title = "MonthStatistice";
        }
    }

    public class PageWidgetConfigModel : WidgetConfigModelBase
    {
        public PageWidgetConfigModel()
        {
            this.Title = "PageWidget";
        }
    }

    public class RecentTopicWidgetConfigModel : WidgetConfigModelBase
    {
        public RecentTopicWidgetConfigModel()
        {
            this.Title = "RecentTopic";
            this.Number = 10;
        }

        public int Number { get; set; }

        public int? Category { get; set; }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && this.Number > 0;
            }
        }
    }

    public class SearchWidgetConfigModel : WidgetConfigModelBase
    {
        public SearchWidgetConfigModel()
        {
            this.Title =    "SearchWidget";
        }
    }

    public class TagWidgetConfigModel : WidgetConfigModelBase
    {
        public TagWidgetConfigModel()
        {
            this.Title = "TagWidget";
            this.Number = 100;
            this.MinTopicNumber = 1;
        }

        public int? Number { get; set; }

        public int MinTopicNumber { get; set; }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && (!this.Number.HasValue || this.Number > 0) && this.MinTopicNumber > 0;
            }
        }
    }

    public class LinkWidgetConfigModel : WidgetConfigModelBase
    {
        public LinkWidgetConfigModel()
        {
            this.Title = "LinkWidget";
            this.LinkList = new List<LinkModel>();
        }

        public List<LinkModel> LinkList { get; set; }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && this.LinkList != null;
            }
        }

        public class LinkModel
        {
            public string Title { get; set; }

            public string Url { get; set; }

            public bool OpenInNewWindow { get; set; }
        }
    }
}
