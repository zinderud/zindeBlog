using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Email
{
    public class TestEmailConfigModel
    {
        public string EmailAddress { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string Server { get; set; }

        public bool EnableSSL { get; set; }
    }
}
