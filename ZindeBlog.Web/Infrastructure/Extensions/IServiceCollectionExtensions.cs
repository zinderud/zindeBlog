using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.Infrastructure.Services;
using ZindeBlog.Web.ViewModels.Setting;

namespace ZindeBlog.Web.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBlogService(this IServiceCollection services)
        {
            var assembly = typeof(IServiceCollectionExtensions).GetTypeInfo().Assembly;
            var serviceList = assembly.DefinedTypes.Where(t => t.Name.EndsWith("Service") && t.Namespace == "ZindeBlog.Web.Infrastructure.Services").ToList();
            foreach (var service in serviceList)
            {
                services.AddScoped(service.AsType());
            }

            services.AddScoped<SettingModel>(provider =>
            {
                return provider.GetService<SettingService>().Get();
            });

            services.AddScoped<ClientManager>();
        }
    }
}
