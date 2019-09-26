using AutoMapper;
using DomainEntities = BravoiSkill.Domain.Entities;
using App = BravoiSkill.Application.DTO;

namespace BravoiSkill.API.Config
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

        }

        public void AddMappings()
        {
            CreateMap<DomainEntities.Users.User, App.Users.User>()
                .ReverseMap();
        }
    }
}
