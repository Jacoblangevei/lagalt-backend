﻿using AutoMapper;
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
                    ppdto => ppdto.Users, options => options.MapFrom(u => u.Users.Select(pp => pp.UserId).ToArray())).ReverseMap();
        }
    }
}
