using AutoMapper;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Models.MessageModels;

namespace Lagalt_Backend.Mappers
{
    public class MessageProfile : Profile
    {
        public MessageProfile() 
        {
            CreateMap<Message, MessagePostDTO>().ReverseMap();

            CreateMap<Message, MessageDTO>()
                .ForMember(
                    mdto => mdto.Replies, options => options.MapFrom(r => r.Replies.Select( m => m.MessageId).ToArray()))
                .ForMember(
                    mdto => mdto.ProjectId, options => options.MapFrom(m => m.ProjectId))
                .ForMember(
                    mdto => mdto.CreatorId, options => options.MapFrom(m => m.UserId)).ReverseMap();
        }
    }
}
