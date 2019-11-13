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
    public class ReviewsController : ControllerBase
    {
        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/reviews
        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _reviewService.GetAll();
            return Ok(reviews);
        }

        // GET api/reviews/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _reviewService.GetById(id);
            return Ok(review);
        }

        // POST api/reviews
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.Review review)
        {
            _reviewService.Create(review);
            return Ok();
        }

        [HttpPut("{id}")]
        // PUT api/reviews/:id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.Review review)
        {
            await _reviewService.Edit(id, review); // varianta cu async
            return Ok();
        }

        [HttpDelete("{id}")]
        // DELETE api/reviews/:id
        public IActionResult Delete(int id)
        {
            _reviewService.Delete(id);
            return Ok();
        }
    }
}
