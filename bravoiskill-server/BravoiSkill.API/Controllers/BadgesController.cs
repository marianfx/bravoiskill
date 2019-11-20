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

        
        // POST api/badges
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.Badge badge)
        {
            _badgeService.Create(badge);
            return Ok();
        }

        
    }
}

