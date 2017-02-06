using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities;
using ZindeBlog.Web.Infrastructure.Repositories.Abstract;

namespace ZindeBlog.Web.Infrastructure.Repositories
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(ZindeBlogContext context)
            : base(context)
        { }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
