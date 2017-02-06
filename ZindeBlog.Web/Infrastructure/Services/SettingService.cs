using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities.Blog;
using ZindeBlog.Web.ViewModels.Setting;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class SettingService
    {
        private ZindeBlogContext BlogContext { get; set; }

        private IMemoryCache Cache { get; set; }

        private static readonly string CacheKey = "Cache_Settings";

        private static object _sync = new object();

        public SettingService(ZindeBlogContext blogContext, IMemoryCache cache)
        {
            BlogContext = blogContext;
            Cache = cache;
        }

        private List<Setting> All()
        {
            var settings = Cache.Get<List<Setting>>(CacheKey);

            if (settings == null)
            {
                try
                {
                    settings = BlogContext.Settings.ToList();
                }
                catch
                {
                    settings = new List<Setting>();
                }
                Cache.Set(CacheKey, settings);
            }

            return settings;
        }

        public SettingModel Get()
        {
            var settings = All();
            var dict = settings.ToDictionary(t => t.Key, t => t.Value);
            return new SettingModel(dict);
        }

        public async Task Save(SettingModel model)
        {
            using (var tran = await BlogContext.Database.BeginTransactionAsync())
            {
                var settings = await BlogContext.Settings.ToListAsync();
                BlogContext.RemoveRange(settings);
                await BlogContext.SaveChangesAsync();

                var entityList = model.Settings.Select(t => new Setting
                {
                    Key = t.Key,
                    Value = t.Value
                });
                BlogContext.AddRange(entityList);

                await BlogContext.SaveChangesAsync();

                tran.Commit();

                Cache.Remove(CacheKey);
            }
        }
    }
}
