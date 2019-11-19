using BravoiSkill.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BravoiSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BadgesController : ControllerBase
    {
        private IBadgeService _badgeService;

        public BadgesController(IBadgeService badgeService)
        {
            _badgeService = badgeService;
        }

        // GET api/badges
        [HttpGet]
        public IActionResult GetAll()
        {
            var badges = _badgeService.GetAll();
            return Ok(badges);
        }

        // GET api/badges/for/:id
        [Route("for/{id}")]
        [HttpGet]
        public IActionResult GetAllFor(int id)
        {
            var ubadges = _badgeService.GetAllFor(id);
            return Ok(ubadges);
        }

        // GET api/badges/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var badge = _badgeService.GetById(id);
            return Ok(badge);
        }

        // POST api/badges
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.Badge badge)
        {
            _badgeService.Create(badge);
            return Ok();
        }

        [HttpPut("{id}")]
        // PUT api/badges/:id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.Badge badge)
        {
            await _badgeService.Edit(id, badge); // varianta cu async
            return Ok();
        }

        [HttpDelete("{id}")]
        // DELETE api/badges/:id
        public IActionResult Delete(int id)
        {
            _badgeService.Delete(id);
            return Ok();
        }
    }
}

