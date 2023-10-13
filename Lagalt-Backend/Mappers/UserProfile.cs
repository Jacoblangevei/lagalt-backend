using AutoMapper;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Dtos.Users;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserPostDTO>().ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(
                    udto => udto.Projects, options => options.MapFrom(u => u.Projects.Select(p => p.ProjectId).ToArray()))
                .ForMember(
                    udto => udto.Skills, options => options.MapFrom(u => u.Skills.Select(s => s.SkillId).ToArray()))
                .ForMember(
                    udto => udto.PortfolioProjects, options => options.MapFrom(u => u.PortfolioProjects.Select(pp => pp.PortfolioProjectId).ToArray()))
                .ForMember(
                    udto => udto.Updates, options => options.MapFrom(u => u.Updates.Select(ud => ud.UpdateId).ToArray()))
                .ForMember(
                    udto => udto.ProjectRequests, options => options.MapFrom(u => u.ProjectRequests.Select(pr => pr.ProjectRequestId).ToArray()))
                .ForMember(
                    udto => udto.Messages, options => options.MapFrom(u => u.Messages.Select(m => m.MessageId).ToArray())).ReverseMap();
            
            CreateMap<User, UserPutDTO>().ReverseMap();

            CreateMap<User, UserProfileDTO>()
                .ForMember(
                    udto => udto.Projects, options => options.MapFrom(u => u.Projects.Select(p => p.ProjectId).ToArray()))
                .ForMember(
                    udto => udto.Skills, options => options.MapFrom(u => u.Skills.Select(s => s.SkillId).ToArray()))
                .ForMember(
                    udto => udto.PortfolioProjects, options => options.MapFrom(u => u.PortfolioProjects.Select(pp => pp.PortfolioProjectId).ToArray())).ReverseMap();

            CreateMap<Skill, UserDTO>().ReverseMap();
        }
    }
}
