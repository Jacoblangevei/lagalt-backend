using AutoMapper;
using Lagalt_Backend.Data.Dtos.PortfolioProjects;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Mappers
{
    public class PortfolioProjectProfile : Profile
    {
        public PortfolioProjectProfile() 
        {
            CreateMap<PortfolioProject, PortfolioProjectPostDTO>();
            CreateMap<PortfolioProject, PortfolioProjectDTO>()
                .ForMember(
                    ppdto => ppdto.Users, options => options.MapFrom(u => u.Users.Select(pp => pp.UserId).ToArray())).ReverseMap();
        }
    }
}
