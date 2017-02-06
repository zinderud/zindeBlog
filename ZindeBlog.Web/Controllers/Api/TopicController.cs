using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Infrastructure.Services;
using ZindeBlog.Web.ViewModels.Tag;
using ZindeBlog.Web.ViewModels.Topic;

namespace ZindeBlog.Web.Controllers.Api
{
    [Area("Api")]
    [Route("api/topic")]
    public class TopicController : ControllerBase
    {
        private TopicService TopicService { get; set; }

        public TopicController(TopicService topicService)
        {
            TopicService = topicService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody]AddTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            var result = await TopicService.Add(model);
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
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody]EditTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            model.ID = id;

            var result = await TopicService.Edit(model);
            if (result.Success)
            {
                return Success(result.Data);
            }
            else
            {
                return Error(result.ErrorMessage);
            }
        }

        [HttpGet("query")]
        public async Task<IActionResult> Query([FromQuery]QueryTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            var result = await TopicService.QueryNotTrash(model.PageIndex, model.PageSize, model.Status, model.Keywords);
            if (result.Success)
            {
                return PagedData(result.Data, result.Total);
            }
            else
            {
                return Error(result.ErrorMessage);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await TopicService.Get(id);
            if (model == null)
            {
                return Error("Eror Get Topic Api ");
            }
            return Success(model);
        }

        [HttpPost("batch/publish")]
        public async Task<IActionResult> BatchPublish([FromBody]BatchTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            await this.TopicService.BatchUpdateStatus(model.TopicList, Infrastructure.Enums.TopicStatus.Published);

            return Success();
        }

        [HttpPost("batch/draft")]
        public async Task<IActionResult> BatchDraft([FromBody]BatchTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            await this.TopicService.BatchUpdateStatus(model.TopicList, Infrastructure.Enums.TopicStatus.Draft);

            return Success();
        }

        [HttpPost("batch/trash")]
        public async Task<IActionResult> BatchTrash([FromBody]BatchTopicModel model)
        {
            if (model == null)
            {
                return InvalidRequest();
            }

            await this.TopicService.BatchUpdateStatus(model.TopicList, Infrastructure.Enums.TopicStatus.Trash);

            return Success();
        }

        [HttpGet("draft")]
        public async Task<IActionResult> QueryDraft(int count)
        {
            if (count < 1)
            {
                return this.InvalidRequest();
            }

            var result = await this.TopicService.QueryNotTrash(1, count, Infrastructure.Enums.TopicStatus.Draft, null);

            return Success(result.Data);
        }
    }
}
