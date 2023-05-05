using AutoMapper;
using Mandiri_API.Models;
using Mandiri_API.Models.Dto;

namespace Mandiri_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<ProjectUsers, ProjectUsersDTO>().ReverseMap();
            CreateMap<UsersDetail, UsersDetailDTO>().ReverseMap();
        }
    }
}
