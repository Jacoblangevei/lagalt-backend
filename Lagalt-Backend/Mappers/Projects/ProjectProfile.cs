using AutoMapper;
using Lagalt_Backend.Data.Models;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Dtos.Projects;
using Microsoft.Extensions.Options;

namespace Lagalt_Backend.Mappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectPostDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>()
                .ForMember(
                    pdto => pdto.Users, options => options.MapFrom(p => p.Users.Select(u => u.UserId).ToArray()))
                .ForMember(
                    pdto => pdto.Tags, options => options.MapFrom(p => p.Tags.Select(t => t.TagId).ToArray()))
                .ForMember(
                    pdto => pdto.Milestones, options => options.MapFrom(p => p.Milestones.Select(m => m.MilestoneId).ToArray()))
                .ForMember(
                    pdto => pdto.Updates, options => options.MapFrom(p => p.Updates.Select(ud => ud.UpdateId).ToArray()))
                .ForMember(
                    pdto => pdto.ProjectRequests, options => options.MapFrom(p => p.ProjectRequests.Select(pr => pr.ProjectRequestId).ToArray()))
                .ForMember(
                    pdto => pdto.Requirements, options => options.MapFrom(p => p.Requirements.Select(r => r.RequirementId).ToArray()))
                .ForMember(
                    pdto => pdto.Messages, options => options.MapFrom(p => p.Messages.Select(msg => msg.MessageId).ToArray()))
                .ForMember(
                    pdto => pdto.OwnerId, options => options.MapFrom(p => p.OwnerId))
                .ForMember(
                    pdto => pdto.ProjectStatusId, options => options.MapFrom(p => p.ProjectStatusId))
                .ForMember(
                    pdto => pdto.ProjectTypeId, options => options.MapFrom(p => p.ProjectTypeId)).ReverseMap();

            CreateMap<Project, ProjectPutDTO>().ReverseMap();
        } 
    }
}
