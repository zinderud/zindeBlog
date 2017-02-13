using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.Infrastructure.Services;
using ZindeBlog.Web.ViewModels.Category;
using ZindeBlog.Web.Controllers.Api;

namespace ZindeBlog.Web.Controllers
{
   // [Area("Api")]
    [Route("api/category")]
    public class CategoryController : Api.ControllerBase
    {
        private CategoryService CategoryService { get; set; }

        public CategoryController(CategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var list = await CategoryService.All();

           // return Json(list);
             return Success(list);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] SaveCategoryModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            OperationResult<int> result = await CategoryService.Add(model.Name, model.Description);

            if (result.Success)
            {
                return Success(result.Data);
            }
            else
            {
                return Error(result.ErrorMessage);
            }
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] SaveCategoryModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            OperationResult result = await CategoryService.Edit(id, model.Name, model.Description);

            if (result.Success)
            {
                return Success();
            }
            else
            {
                return Error(result.ErrorMessage);
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveCategoryModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            await CategoryService.Remove(model.IDList);

            return Success();
        }
    }
}
