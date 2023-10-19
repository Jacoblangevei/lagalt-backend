using AutoMapper;
using Lagalt_Backend.Data.Dtos.Requirements;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class RequirementProfile : Profile
    {
        public RequirementProfile() 
        {
            CreateMap<Requirement, RequirementPostDTO>().ReverseMap();
            CreateMap<Requirement, RequirementDTO>()
                .ForMember(
                    rdto => rdto.Projects, options => options.MapFrom(p => p.Projects.Select(r => r.ProjectId).ToArray())).ReverseMap();
        }
    }
}
