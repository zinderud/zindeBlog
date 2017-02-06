using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.ViewModels;

namespace ZindeBlog.Web.Infrastructure.Filters
{
    public class ErrorHandlerFilter : ExceptionFilterAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext context)
        {
            Logger.Error(context.Exception, context.Exception.Message);

            var apiResponse = new ApiResponse
            {
                Success = false,
                ErrorMessage = "Error api"
            };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new JsonResult(apiResponse);
        }
    }
}
