using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Page
{
    public class BatchPageModel
    {
        [Required]
        public int[] PageList { get; set; }
    }
}
