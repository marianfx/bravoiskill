using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Infrastructure.Repositories.Users
{
    public class BadgeRepository : IBadgeRepository
    {
        private BravoiSkillDbContext _context;
        public BadgeRepository(BravoiSkillDbContext context)
        {
            _context = context;
        }

        public IQueryable<Badge> GetListOfBadges()
        {
            var rez = from d in _context.Badges
                      select d;
            return rez;
        }
        public IQueryable<Badge> GetListOfBadgesFor(int id)
        {
            var rez = _context.UserBadges.Where(d => d.UserId == id).Include(s => s.Badge).Select(s => s.Badge);
            return rez;

        }

        public Badge GetActiveBadgeById(int id)
        {
            var rez = from d in _context.Badges
                      where d.BadgeId == id
                      select d;
            return rez.FirstOrDefault();
        }

        public Badge Create(Badge badge)
        {
            _context.Set<Badge>().Add(badge);
            _context.SaveChanges();
            return badge;
        }

        public Badge Update(Badge badge)
        {
            _context.Entry(badge).State = EntityState.Modified;
            _context.SaveChanges();
            return badge;
        }

        public void Delete(Badge badge)
        {
            _context.Set<Badge>().Remove(badge);
            _context.SaveChanges();
        }
    }
}

