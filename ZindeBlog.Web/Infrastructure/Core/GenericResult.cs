using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Infrastructure.Core
{
    
    public class GenericResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
