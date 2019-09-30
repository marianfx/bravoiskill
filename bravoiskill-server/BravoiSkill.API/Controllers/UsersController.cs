using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Application.DTO.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BravoiSkill.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace BravoiSkill.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Application.DTO.Users.User userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Password);
            
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create(Application.DTO.Users.User user)
        {
            _userService.Create(user);
            return Ok();
        }
    }
    }