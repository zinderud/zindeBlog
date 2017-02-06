using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Comment
{
    public class BatchCommentModel
    {
        [Required]
        public int[] CommentList { get; set; }
    }
}
