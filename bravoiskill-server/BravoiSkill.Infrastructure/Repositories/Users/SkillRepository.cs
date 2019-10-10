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
    public class SkillRepository : ISkillRepository
    {
        private BravoiSkillDbContext _context;
        public SkillRepository(BravoiSkillDbContext context)
        {
            _context = context;

        }

        public IQueryable<Skill> GetListOfSkills()
        {
            var skills = _context.Skills.Include(s => s.SkillCategory);
            return skills;
        }

        public Skill GetSkillById(int id)
        {
            var rez = from us in _context.Skills
                      where us.SkillId == id
                      select us;
            return rez.FirstOrDefault();
        }

        public Skill Create(Skill skill)
        {
            _context.Set<Skill>().Add(skill);
            _context.SaveChanges();
            return skill;
        }

        public Skill Update(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
            _context.SaveChanges();
            return skill;
        }

        public void Delete(Skill skill)
        {
            _context.Set<Skill>().Remove(skill);
            _context.SaveChanges();
        }

    }
}

