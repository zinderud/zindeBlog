using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.Infrastructure.Services;
using ZindeBlog.Web.ViewModels.My;

namespace ZindeBlog.Web.Controllers.Api
{
    [Route("api/my")]
    public class MyController : ControllerBase
    {
        private ClientManager ClientManager { get; set; }

        private UserService UserService { get; set; }

        public MyController(ClientManager clientManager, UserService userService)
        {
            this.ClientManager = clientManager;
            this.UserService = userService;
        }

        [HttpGet("")]
        public IActionResult GetMyInfo()
        {
            var user = this.ClientManager.CurrentUser;
            return this.Success(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> EditMyInfo([FromBody]EditMyInfoModel model)
        {
            if (model == null)
            {
                return this.InvalidRequest();
            }

            var result = await this.UserService.EditUserInfo(this.ClientManager.CurrentUser.Id, model.Email, model.Nickname);

            if (result.Success)
            {
                return this.Success();
            }
            else
            {
                return this.Error(result.ErrorMessage);
            }
        }
    }
}
