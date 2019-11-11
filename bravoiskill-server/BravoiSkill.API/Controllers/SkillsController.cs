using Microsoft.AspNetCore.Mvc;
using BravoiSkill.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace BravoiSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController: ControllerBase
    {
        private ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _skillService.GetAll();
            return Ok(skills);
        }

        // GET api/skills/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skill = _skillService.GetById(id);
            return Ok(skill);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.Skill skill)
        {
            _skillService.Create(skill);
            return Ok();
        }

        [HttpPut("{id}")]
        // PUT api/skills/:id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.Skill skill)
        {
            await _skillService.Edit(id, skill); // varianta cu async
            return Ok();
        }

        [HttpDelete("{id}")]
        // DELETE api/skills/:id
        public IActionResult Delete(int id)
        {
            _skillService.Delete(id);
            return Ok();
        }
    }
}

