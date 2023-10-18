using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.ProjectStatuses;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class ProjectStatusProfile : Profile
    {
        public ProjectStatusProfile() 
        {
            CreateMap<ProjectStatus, ProjectStatusDTO>()
                .ForMember(
                    psdto => psdto.Projects, options => options.MapFrom(p => p.Projects.Select(ps => ps.ProjectId).ToArray())).ReverseMap();
        }
    }
}
