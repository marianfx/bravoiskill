using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BravoiSkill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private BravoiSkillDbContext _context;
        public UsersController(BravoiSkillDbContext context)
        {
            _context = context;
        }

        // GET api/users
       [HttpGet]
        public IEnumerable<User> Get()
        {
            return GetListOfUsers() // build query
                .ToList(); // execute
        }
        public IQueryable<User> GetListOfUsers()
        {
            var rez = from us in _context.Users
                      where us.UserId == 1
                      select us;
            return rez;
        }
    }
}