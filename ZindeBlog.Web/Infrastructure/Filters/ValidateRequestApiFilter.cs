using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ZindeBlog.Web.Infrastructure.Filters
{
    public class ValidateRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                this.HandleInvalidRequest(context);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }

        protected virtual void HandleInvalidRequest(ActionExecutingContext context)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
    }
    public class ValidateRequestApiFilter : ValidateRequestFilter
    {
        protected override void HandleInvalidRequest(ActionExecutingContext context)
        {
            var controller = context.Controller as Controllers.Api.ControllerBase;
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = controller.InvalidRequest();
        }
    }
}
