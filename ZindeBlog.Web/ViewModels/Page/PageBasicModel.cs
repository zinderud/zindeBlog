using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Page
{
    public class PageBasicModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }

        public PageBasicModel Parent { get; set; }

        public int Order { get; set; }

        public DateTime Date { get; set; }

        public bool IsHomePage { get; set; }

        public bool ShowInList { get; set; }

        public Infrastructure.Enums.PageStatus Status { get; set; }
    }
}
