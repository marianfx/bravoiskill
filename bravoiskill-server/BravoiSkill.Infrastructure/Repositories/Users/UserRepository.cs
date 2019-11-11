using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BravoiSkill.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private BravoiSkillDbContext _context;
        public UserRepository(BravoiSkillDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetListOfUsers()
        {
            var rez = from us in _context.Users
                      select us;
            return rez;
        }

        public User GetUserById(int id)
        {
            var rez = from us in _context.Users
                      where us.UserId == id
                      select us;
            return rez.FirstOrDefault();
        }

        public User Create(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Set<User>().Remove(user);
            _context.SaveChanges();
        }
    }
}
