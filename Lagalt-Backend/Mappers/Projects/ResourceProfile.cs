using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.Resources;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers.Projects
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile() 
        {
            CreateMap<Resource, ResourcePostDTO>().ReverseMap();   
            CreateMap<Resource, ResourceDTO>()
                .ForMember(
                rdto => rdto.ProjectId, options => options.MapFrom(p => p.ProjectId)).ReverseMap();
        }
    }
}
