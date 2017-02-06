using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities
{
    public class Role : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
