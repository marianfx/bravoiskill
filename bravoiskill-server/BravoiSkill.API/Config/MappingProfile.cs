using AutoMapper;
using DomainEntities = BravoiSkill.Domain.Entities;
using App = BravoiSkill.Application.DTO;

namespace BravoiSkill.API.Config
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            AddMappings();
        }

        public void AddMappings()
        {
            CreateMap<App.Users.User, DomainEntities.Users.User>()
                .ReverseMap();

            CreateMap<App.Users.Department, DomainEntities.Users.Department>()
                .ReverseMap();
            CreateMap<App.Users.Skill, DomainEntities.Users.Skill>()
                .ReverseMap();
        }
    }
}
