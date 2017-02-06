using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Page
{
    public class PageCountModel
    {
        public int Published { get; set; }

        public int Draft { get; set; }

        public int All { get; set; }
    }
}
