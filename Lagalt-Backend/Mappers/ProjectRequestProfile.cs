using AutoMapper;
using Lagalt_Backend.Data.Dtos.ProjectRequests;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class ProjectRequestProfile : Profile
    {
        public ProjectRequestProfile()
        {
            CreateMap<ProjectRequest, ProjectRequestDTO>()
                .ForMember(
                    prdto => prdto.UserId, options => options.MapFrom(u => u.UserId))
                .ForMember(
                    prdto => prdto.ProjectId, options => options.MapFrom(p => p.ProjectId)).ReverseMap();
        }
    }
}
