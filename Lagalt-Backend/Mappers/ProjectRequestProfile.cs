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
            // Mapping from Entity to DTO
            CreateMap<ProjectRequest, ProjectRequestDTO>()
                .ForMember(
                    dto => dto.ProjectName,
                    options => options.MapFrom(pr => pr.Project.Name)) 
                .ForMember(
                    dto => dto.UserId,
                    options => options.MapFrom(pr => pr.User.UserName));

            // Mapping from DTO to Entity 
            CreateMap<ProjectRequestDTO, ProjectRequest>();
        }
    }
}
