using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using ZindeBlog.Web.Infrastructure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace ZindeBlog.Web.Infrastructure.Filters
{
    public class RequireLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ClientManager clientManager = context.HttpContext.RequestServices.GetService<ClientManager>();
            if (!clientManager.IsLogin)
            {
                this.HandleUnauthorizedRequest(context);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }

        protected virtual void HandleUnauthorizedRequest(ActionExecutingContext context)
        {
            string sourceUrl = null;
            if (context.HttpContext.Request.Path.HasValue)
            {
                sourceUrl = context.HttpContext.Request.Path.Value;

                if (context.HttpContext.Request.QueryString.HasValue)
                {
                    sourceUrl += context.HttpContext.Request.QueryString.Value;
                }
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            context.Result = new RedirectToActionResult("Login", "Account", new { redirect = sourceUrl });

        }
    }
    public class RequireLoginApiFilter : RequireLoginFilter
    {
        protected override void HandleUnauthorizedRequest(ActionExecutingContext context)
        {
            var controller = context.Controller as Controllers.Api.ControllerBase;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = controller.Error("RequireLogin Error");
        }
    }
}
