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

            CreateMap<App.Users.Badge, DomainEntities.Users.Badge>()
                .ReverseMap();
            CreateMap<App.Users.Department, DomainEntities.Users.Department>()
                .ReverseMap();
            CreateMap<App.Users.Profile, DomainEntities.Users.Profile>()
                .ReverseMap();
            CreateMap<App.Users.Review, DomainEntities.Users.Review>()
                .ReverseMap();
            CreateMap<App.Users.Skill, DomainEntities.Users.Skill>()
                .ReverseMap();
            CreateMap<App.Users.SkillCategory, DomainEntities.Users.SkillCategory>()
                .ReverseMap();
            CreateMap<App.Users.SkillReview, DomainEntities.Users.SkillReview>()
                .ReverseMap();
            CreateMap<App.Users.UserBadge, DomainEntities.Users.UserBadge>()
                .ReverseMap();
            CreateMap<App.Users.UserSkill, DomainEntities.Users.UserSkill>()
                .ReverseMap();
        }
    }
}
