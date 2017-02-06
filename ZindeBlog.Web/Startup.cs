using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IO;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ZindeBlog.Web.Infrastructure;
using ZindeBlog.Web.Infrastructure.Repositories.Abstract;
using ZindeBlog.Web.Infrastructure.Services.Abstract;
using ZindeBlog.Web.Infrastructure.Repositories;
using ZindeBlog.Web.Infrastructure.Services;
using ZindeBlog.Web.Infrastructure.Mappings;
using ZindeBlog.Web.Infrastructure.Extensions;
using Microsoft.Extensions.FileProviders;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;
 

namespace ZindeBlog.Web
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
            
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration["connectionstrings"];



            string database = this.Configuration["database"];
            services.AddDbContext<ZindeBlogContext>(options =>
            {



                options.UseSqlServer(sqlConnectionString);

            });



            //if ("sqlite".Equals(database, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    services.AddEntityFrameworkSqlite()
            //        .AddDbContext<ZindeBlogContext>(opt =>
            //        {
            //            opt.UseSqlite(this.Configuration["connectionstring"], builder => { builder.MigrationsAssembly("ZindeBlog.Web"); });
            //        });
            //}
            //else if ("sqlserver".Equals(database, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    services.AddEntityFrameworkSqlServer()
            //        .AddDbContext<ZindeBlogContext>(opt =>
            //        {
            //            opt.UseSqlServer(this.Configuration["connectionstring"], builder =>
            //            {
            //                builder.MigrationsAssembly("ZindeBlog.Web");
            //                builder.UseRowNumberForPaging();
            //            });
            //        });
            //}
            //else if ("InMemoryProvider".Equals(database, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    services.AddDbContext<ZindeBlogContext>(options =>
            //    {


            //        options.UseInMemoryDatabase();
            //        //options.UseSqlServer(sqlConnectionString);

            //    });
            //}


            // Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILoggingRepository, LoggingRepository>();

            // Services
           services.AddBlogService();

            //services.AddScoped<IMembershipService, MembershipService>();
            //services.AddScoped<IEncryptionService, EncryptionService>();
            //services.AddScoped< CategoryService>();
            services.AddAuthentication();

            // Polices
            services.AddAuthorization(options =>
            {
                // inline policies
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });

            });

            // Add MVC services to the services container.
            services.AddMvc()
            .AddJsonOptions(opt =>
            {
                var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;
                }
            });
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment enviroment, ILoggerFactory loggerFactory)
        {

            string uploadFolder = enviroment.ContentRootPath + "wwwroot/App_Data/upload";
            Directory.CreateDirectory(uploadFolder);
            if (enviroment.IsDevelopment())
            {
                string databaseFolder = enviroment.ContentRootPath + "wwwroot/App_Data";
                Directory.CreateDirectory(databaseFolder);
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/upload"),
                FileProvider = new PhysicalFileProvider(uploadFolder)
            });

            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseExceptionHandler("/Exception/Error.cshtml");
            //app.UseStatusCodePagesWithReExecute("/exception/{0}");

           // app.UseClientManager();

         

            loggerFactory.AddNLog();
            enviroment.ConfigureNLog("NLog.config");
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            // this will serve up wwwroot
            app.UseStaticFiles();

            AutoMapperConfiguration.Configure();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            // Custom authentication middleware
            //app.UseMiddleware<AuthMiddleware>();

            // Add MVC to the request pipeline.

           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                //routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

      DbInitializer.Initialize(app.ApplicationServices);
        }

        // Entry point for the application.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>()
              .Build();

            host.Run();
        }
    }
}
