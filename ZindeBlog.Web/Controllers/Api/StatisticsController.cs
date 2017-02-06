using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Services;

namespace ZindeBlog.Web.Controllers.Api
{
    [Area("Api")]
    [Route("api/statistics")]
    [Infrastructure.Filters.RequireLoginApiFilter]
    public class StatisticsController : ControllerBase
    {
        private StatisticsService StatisticsService { get; set; }

        public StatisticsController(StatisticsService statisticsService)
        {
            this.StatisticsService = statisticsService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = await this.StatisticsService.GetBlogStatistics();

            return this.Success(model);
        }
    }
}
