using Microsoft.AspNetCore.Mvc;
using BravoiSkill.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace BravoiSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET api/departments
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            return Ok(departments);
        }

        // GET api/departments/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = _departmentService.GetById(id);
            return Ok(department);
        }

        // POST api/departments
        [HttpPost]
        public IActionResult Create([FromBody]Application.DTO.Users.Department department)
        {
            _departmentService.Create(department);
            return Ok();
        }

        [HttpPut("{id}")]
        // PUT api/departments/:id
        public async Task<IActionResult> Edit(int id, [FromBody]Application.DTO.Users.Department department)
        {
           await _departmentService.Edit(id, department); // varianta cu async
            return Ok();
        }

        [HttpDelete("{id}")]
        // DELETE api/departments/:id
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return Ok();
        }
    }
}