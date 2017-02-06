using AutoMapper;
using System.Linq;

namespace ZindeBlog.Web.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<model, ModelViewModel>()
            //   .ForMember(vm => vm.Uri, map => map.MapFrom(p => "/images/" + p.Uri));

           
        }
    }
}
