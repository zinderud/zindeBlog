using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.ViewModels.Comment;
using ZindeBlog.Web.ViewModels.Page;
using ZindeBlog.Web.ViewModels.Statistics;
using ZindeBlog.Web.ViewModels.Topic;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class StatisticsService
    {
        private ZindeBlogContext BlogContext { get; set; }

        public StatisticsService(ZindeBlogContext blogContext)
        {
            this.BlogContext = blogContext;
        }

        public async Task<BlogStatisticsModel> GetBlogStatistics()
        {
            var model = new BlogStatisticsModel
            {
                Comments = new  CommentCountModel(),
                Pages = new  PageCountModel(),
                Topics = new   TopicCountModel()
            };

            var topicQuery = await this.BlogContext.Topics.GroupBy(t => t.Status)
                .ToDictionaryAsync(t => t.Key, t => t.Count());

            var pageQuery = await this.BlogContext.Pages.GroupBy(t => t.Status)
                .ToDictionaryAsync(t => t.Key, t => t.Count());

            var commentQuery = await this.BlogContext.Comments.GroupBy(t => t.Status)
                .ToDictionaryAsync(t => t.Key, t => t.Count());

            if (topicQuery.ContainsKey(Enums.TopicStatus.Published))
            {
                model.Topics.Published = topicQuery[Enums.TopicStatus.Published];
            }
            if (topicQuery.ContainsKey(Enums.TopicStatus.Trash))
            {
                model.Topics.Draft = topicQuery[Enums.TopicStatus.Trash];
            }
            model.Topics.All = topicQuery.Sum(t => t.Value);

            if (pageQuery.ContainsKey(Enums.PageStatus.Published))
            {
                model.Pages.Published = pageQuery[Enums.PageStatus.Published];
            }
            if (pageQuery.ContainsKey(Enums.PageStatus.Draft))
            {
                model.Pages.Draft = pageQuery[Enums.PageStatus.Draft];
            }
            model.Pages.All = pageQuery.Sum(t => t.Value);

            if (commentQuery.ContainsKey(Enums.CommentStatus.Approved))
            {
                model.Comments.Approved = commentQuery[Enums.CommentStatus.Approved];
            }
            if (commentQuery.ContainsKey(Enums.CommentStatus.Pending))
            {
                model.Comments.Pending = commentQuery[Enums.CommentStatus.Pending];
            }
            if (commentQuery.ContainsKey(Enums.CommentStatus.Reject))
            {
                model.Comments.Reject = commentQuery[Enums.CommentStatus.Reject];
            }
            model.Comments.Total = commentQuery.Sum(t => t.Value);

            return model;
        }
    }
}
