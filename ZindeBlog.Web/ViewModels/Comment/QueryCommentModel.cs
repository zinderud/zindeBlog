using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Comment
{
    public class QueryCommentModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public Infrastructure.Enums.CommentStatus? Status { get; set; }

        public string Keywords { get; set; }
    }
}
