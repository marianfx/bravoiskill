using AutoMapper;
using BravoiSkill.Application.DTO.Users;
using BravoiSkill.Application.Services.Interfaces;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Implementations
{
    public class BadgeService : IBadgeService
    {
        private IBadgeRepository _badgeRepository;
        private IMapper _mapper;

        public BadgeService(IBadgeRepository badgeRepository,
            IMapper mapper)
        {
            _badgeRepository = badgeRepository;
            _mapper = mapper;
        }

        public IEnumerable<Badge> GetAll()
        {
            var badgesDb = _badgeRepository.GetListOfBadges();
            var badgesDto = badgesDb
                .Select(badgeDb => _mapper.Map<Badge>(badgeDb))
                .ToList();

            return badgesDto;
        }
        public IEnumerable<UserBadge> GetAllFor(int id)
        {
            var uBadgesDb = _badgeRepository.GetListOfBadgesFor(id);
            var uBadgesDto = uBadgesDb.Select(uBadgeDb => _mapper.Map<UserBadge>(uBadgeDb))
                .ToList();

            return uBadgesDto;
        }

        public Badge GetById(int id)
        {
            var badgeDb = _badgeRepository.GetBadgeById(id);
            return _mapper.Map<Badge>(badgeDb);
        }

        public void Create(Badge badge)
        {
            var badgeEntity = _mapper.Map<Domain.Entities.Users.Badge>(badge);
            _badgeRepository.Create(badgeEntity);
        }

        public async Task Edit(int id, Badge badge)
        {
            badge.Validate();
            if (badge.HasErrors)
                throw new Exception(badge.Errors[0]);

            var badgeEntity = _badgeRepository.GetBadgeById(id);
            if (badgeEntity == null)
                throw new Exception("Badge does not exist in database");
            badge.BadgeId = badgeEntity.BadgeId;

            _mapper.Map<Badge, Domain.Entities.Users.Badge>(badge, badgeEntity);
            _badgeRepository.Update(badgeEntity);
        }

        public void Delete(int id)
        {
            var badgeEntity = _badgeRepository.GetBadgeById(id);
            if (badgeEntity == null)
                throw new Exception("Badge does not exist in database");

            _badgeRepository.Delete(badgeEntity);
        }

       
    }
}

