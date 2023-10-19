using AutoMapper;
using Lagalt_Backend.Data.Dtos.Skills;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Mappers
{
    public class SkillProfile : Profile
    {
        public SkillProfile() 
        {
            CreateMap<Skill, SkillPostDTO>().ReverseMap();
            CreateMap<Skill, SkillDTO>()
                .ForMember(
                    sdto => sdto.Users, options => options.MapFrom(u => u.Users.Select(s => s.UserId).ToArray())).ReverseMap();
        }
    }
}
