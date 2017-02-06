using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Comment
{
    public class ReplyCommentModel
    {
        public int ReplyTo { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
