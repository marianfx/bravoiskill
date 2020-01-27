using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public IQueryable<SkillCategory> GetAllSkillCategories()
        {
            var skillCategories = _context.SkillCategories.Where(x => x.ParentId == null);
            return skillCategories;
        }

        public IQueryable<SkillCategory> GetAllSkillSubCategories()
        {
            var skillSubCategories = _context.SkillCategories.Where(x => x.ParentId != null);
            return skillSubCategories;
        }

        public IQueryable<UserSkill> GetUserSkillsByUserId(int id)
        {
            var rez = _context.UserSkills.Where(us => us.UserId == id).Include(b => b.Skill);
            return rez;
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

