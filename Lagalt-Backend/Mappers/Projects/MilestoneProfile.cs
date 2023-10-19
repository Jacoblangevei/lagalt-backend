using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.Milestones;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers.Projects
{
    public class MilestoneProfile : Profile
    {
        public MilestoneProfile() 
        {
            CreateMap<Milestone, MilestonePostDTO>().ReverseMap();
            CreateMap<Milestone, MilestoneDTO>()
                .ForMember(
                mdto => mdto.ProjectId, options => options.MapFrom(m => m.ProjectId))
                .ForMember(
                mdto => mdto.MilestoneStatusId, options => options.MapFrom(m => m.MilestoneStatusId)).ReverseMap();

            CreateMap<Milestone, MilestonePutDTO>().ReverseMap();
        }
    }
}
