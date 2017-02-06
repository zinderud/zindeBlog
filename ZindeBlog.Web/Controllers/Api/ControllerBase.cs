using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZindeBlog.Web.Infrastructure.Filters;
using ZindeBlog.Web.ViewModels;

namespace ZindeBlog.Web.Controllers.Api
{
    [ErrorHandlerFilter]
   // [RequireLoginApiFilter]
    [ValidateRequestApiFilter]
    public class ControllerBase : Controller
    {
        private static readonly JsonSerializerSettings _DefaultJsonSerializerSettings;

        static ControllerBase()
        {
            _DefaultJsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatString = "MM-dd-yyyy HH:mm:ss",
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [NonAction]
        public IActionResult Success()
        {
            var response = new ApiResponse
            {
                Success = true
            };

            return Json(response);
        }

        [NonAction]
        public IActionResult Error(string errorMessage)
        {
            var response = new ApiResponse
            {
                ErrorMessage = errorMessage
            };

            return Json(response);
        }

        [NonAction]
        public IActionResult Success<T>(T data)
        {
            var response = new ApiResponse<T>
            {
                Success = true,
                Data = data
            };

            return Json(response);
        }

        [NonAction]
        public IActionResult PagedData<T>(List<T> data, int total)
        {
            var response = new PagedApiResponse<T>
            {
                Success = true,
                Data = data,
                Total = total
            };

            return Json(response);
        }

        [NonAction]
        public new IActionResult Json(object data)
        {
            return base.Json(data, _DefaultJsonSerializerSettings);
        }

        [NonAction]
        public IActionResult InvalidRequest()
        {
            string errorMessage;

            if (ModelState.IsValid)
            {
                errorMessage = "InvalidRequest";
            }
            else
            {
                errorMessage = ModelState.Where(t => t.Value.Errors.Any()).Select(t => t.Value).FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage;
            }

            errorMessage = string.IsNullOrWhiteSpace(errorMessage) ? "Error" : errorMessage;

            return this.Error(errorMessage);
        }
    }
}
