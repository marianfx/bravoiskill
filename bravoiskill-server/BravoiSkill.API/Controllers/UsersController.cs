using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BravoiSkill.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace BravoiSkill.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IBadgeService _badgeService;
        private ISkillService _skillService;

        public UsersController(IUserService userService, IBadgeService badgeService, ISkillService skillService)
        {
            _userService = userService;
            _badgeService = badgeService;
            _skillService = skillService;
        }

        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
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
        // GET api/users/:id/userskills
        [HttpGet("{id}/userskills")]
        public IActionResult GetUserSkillsByUserId(int id)
        {
            var user = _skillService.GetByUserId(id);
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
        // PUT api/users/:id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.User user)
        {
            // _userService.Edit(id, user).GetAwaiter().GetResult(); // varianta transforma async in sync
            await _userService.Edit(id, user); // varianta cu async
            return Ok();
        }

        [HttpDelete("{id}")]
        // DELETE api/users/:id
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        // POST api/users/:id/photo
        [Route("{id}/photo")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(int id)
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault();

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file != null && file.Length > 0)
                {
                    var fileName = "image_" + Guid.NewGuid() + "." + file.FileName.Split(".").LastOrDefault();
                    var fullPath = Path.Combine(pathToSave, fileName);

                    var user = _userService.GetById(id);
                    user.Photo = fileName;
                    _userService.Edit(id, user);

                    var dbPath = Path.Combine(folderName, fileName.ToString());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { fileName = fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // return server.map()
        // GET api/profileimage/id
        [AllowAnonymous]
        [Route("{id}/photo")]
        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var filename = _userService.GetById(id).Photo;

                if (filename == null)
                    filename = "default.png";

                var path = Path.Combine(folderPath, filename);
                var file = System.IO.File.OpenRead(path);
                if (file == null)
                    return BadRequest("Not Found");
                return File(file, "image/*", filename); // returns a FileStreamResult
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        // GET api/users/:id/badges
        [Route("{id}/badges")]
        [HttpGet]
        public IActionResult GetAllFor(int id)
        {
            var ubadges = _badgeService.GetAllFor(id);
            return Ok(ubadges);
        }

        // GET api/users/:id/badge
        [HttpGet("{id}/badge")]
        public IActionResult GetActiveBadgeById(int id)
        {
            var badge = _badgeService.GetActiveBadgeById(id);
            return Ok(badge);
        }

        // PUT api/users/:id/badge
        [HttpPut("{id}/badge")]
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.Badge badge)
        {
            await _badgeService.Edit(id, badge); // varianta cu async
            return Ok();
        }

        // DELETE api/users/:id/badge
        [HttpDelete("{id}/badge")]
        public IActionResult DeleteBadge(int id)
        {
            _badgeService.Delete(id);
            return Ok();
        }
    }
}