using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.Milestones;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers.Projects
{
    public class MilestoneStatusProfile : Profile
    {
        public MilestoneStatusProfile() 
        {
            CreateMap<MilestoneStatus, MilestoneStatusDTO>()
                .ForMember(
                pdto => pdto.Milestones, options => options.MapFrom(ms => ms.Milestones.Select(m => m.MilestoneId).ToArray())).ReverseMap();
        }
    }
}
