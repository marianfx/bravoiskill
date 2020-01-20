using Microsoft.AspNetCore.Mvc;
using BravoiSkill.Application.Services.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using OfficeOpenXml;
using System;

namespace BravoiSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
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
        // GET api/skills/categories
        [HttpGet("categories")]
        public IActionResult GetAllCategories()
        {
            var skills = _skillService.GetAllCategories();
            return Ok(skills);
        }
        // GET api/skills/subCategories
        [HttpGet("subCategories")]
        public IActionResult GetAllSubCategories()
        {
            var skills = _skillService.GetAllSubCategories();
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
        // GET api/skills/export
        [AllowAnonymous]
        [HttpGet("export")]
        public async Task<IActionResult> ExportV2(CancellationToken cancellationToken)
        {
            // query data from database  
            await Task.Yield();
            var list = _skillService.GetAll();

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"SkillList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}

