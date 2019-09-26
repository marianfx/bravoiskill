using BravoiSkill.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Infrastructure.Repositories.Users
{
    public class UserRepository
    {
        private BravoiSkillDbContext _context;
        public UserRepository(BravoiSkillDbContext context)
        {
            _context = context;
           
        }

        public IQueryable<Domain.Entities.Users.User> GetListOfUsers()
        {
            var rez = from us in _context.Users
                      select us;
            return rez;
        }
    }
}
