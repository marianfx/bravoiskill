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

        // GET api/users/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.User user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpPut("{id}")]
        // PUT api/users/id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.User user)
        {
            // _userService.Edit(id, user).GetAwaiter().GetResult(); // varianta transforma async in sync
            await _userService.Edit(id, user); // varianta cu async
            return Ok();

        }

        [HttpDelete("{id}")]
        // DELETE api/users/id
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();

        }
    }
}