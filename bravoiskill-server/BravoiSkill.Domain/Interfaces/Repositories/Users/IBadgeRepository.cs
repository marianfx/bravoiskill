using BravoiSkill.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
    public interface IBadgeRepository
    {
        IQueryable<Badge> GetListOfBadges();
        IQueryable<UserBadge> GetListOfBadgesFor(int id);

        Badge GetBadgeById(int id);

        Badge Create(Badge badge);

        Badge Update(Badge badge);

        void Delete(Badge user);
    }
}
