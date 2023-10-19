using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.Updates;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Mappers
{
    public class UpdateProfile : Profile
    {
        public UpdateProfile() 
        {
            CreateMap<Update, UpdatePostDTO>().ReverseMap();
            CreateMap<Update, UpdateDTO>()
                .ForMember(
                    udto => udto.ProjectId, options => options.MapFrom(p => p.ProjectId))
                .ForMember(
                    udto => udto.UserId, options => options.MapFrom(u => u.UserId)).ReverseMap();
        }

    }
}
