using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities.Blog;
using ZindeBlog.Web.ViewModels.Config;
using ZindeBlog.Web.ViewModels.Page;
using ZindeBlog.Web.ViewModels.Setting;
using ZindeBlog.Web.ViewModels.Topic;

namespace ZindeBlog.Web.Infrastructure.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToViewModelMappingProfile>();
                config.CreateMap<BasicConfigModel, SettingModel>();
                config.CreateMap<SettingModel, BasicConfigModel>();
                config.CreateMap<EmailConfigModel, SettingModel>();
                config.CreateMap<SettingModel, EmailConfigModel>();
                config.CreateMap<SettingModel, CommentConfigModel>();
                config.CreateMap<CommentConfigModel, SettingModel>();
                config.CreateMap<SettingModel, AdvanceConfigModel>();
                config.CreateMap<AdvanceConfigModel, SettingModel>();

                config.CreateMap<Topic, TopicModel>().ForMember(dest => dest.Date, map => map.MapFrom(source => source.EditDate));
                config.CreateMap<Page, PageModel>().ForMember(dest => dest.Date, map => map.MapFrom(source => source.EditDate));
                config.CreateMap<Page, PageBasicModel>().ForMember(dest => dest.Date, map => map.MapFrom(source => source.EditDate));
                config.CreateMap<AddPageModel, Page>();
                config.CreateMap<EditPageModel, Page>();

            });
        }
    }
}
