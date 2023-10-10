using AutoMapper;
using Lagalt_Backend.Data.Dtos.Owners;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile() 
        {
            CreateMap<Owner, OwnerPostDTO>().ReverseMap();

            CreateMap<Owner, OwnerDTO>()
                .ForMember(
                    odto => odto.Comments, options => options.MapFrom(o => o.Comments.Select(c => c.CommentId).ToArray()))
                .ForMember(
                    odto => odto.Projects, options => options.MapFrom(o => o.Projects.Select(p => p.ProjectId).ToArray()))
                .ForMember(
                    odto => odto.UserReviews, options => options.MapFrom(o => o.UserReviews.Select(ur => ur.UserReviewId).ToArray()))
                .ForMember(
                    odto => odto.Messages, options => options.MapFrom(o => o.Messages.Select(m => m.MessageId).ToArray())).ReverseMap();
        }
    }
}
