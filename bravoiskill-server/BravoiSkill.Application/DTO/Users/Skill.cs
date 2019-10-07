using BravoiSkill.Application.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace BravoiSkill.Application.DTO.Users
{
    public class Skill: BaseDto
    {
        public int SkillId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
