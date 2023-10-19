using AutoMapper;
using Lagalt_Backend.Data.Dtos.ProjectTypes;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class ProjectTypeProfile : Profile
    {
        public ProjectTypeProfile() 
        {

            CreateMap<ProjectType, ProjectTypeDTO>()
                .ForMember(
                    ptdto => ptdto.Projects, options => options.MapFrom(pt => pt.Projects.Select(p => p.ProjectId).ToArray())).ReverseMap();
        }
    }
}
