using AutoMapper;
using Lagalt_Backend.Data.Dtos.Comments;
using Lagalt_Backend.Data.Models.MessageModels;

namespace Lagalt_Backend.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile() 
        {
            CreateMap<Comment, CommentPostDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>()
                .ForMember(
                    cdto => cdto.MessageId, option => option.MapFrom(c => c.MessageId))
                .ForMember(
                    mdto => mdto.CreatorId, options => options.MapFrom(c => c.CreatorId)).ReverseMap();
        }
    }
}
