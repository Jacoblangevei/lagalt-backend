using AutoMapper;
using Lagalt_Backend.Data.Dtos.Tags;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile() 
        {
            CreateMap<Tag, TagPostDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>()
                .ForMember(
                    tdto => tdto.Projects, options => options.MapFrom(p => p.Projects.Select(t => t.ProjectId).ToArray())).ReverseMap();
        }
    }
}
