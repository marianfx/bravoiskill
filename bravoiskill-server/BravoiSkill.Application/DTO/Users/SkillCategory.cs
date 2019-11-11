using BravoiSkill.Application.DTO.Shared;
using System.Collections.Generic;

namespace BravoiSkill.Application.DTO.Users
{
    public class SkillCategory : BaseDto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public SkillCategory Parent { get; set; }

        public IList<SkillCategory> Children { get; set; }
    }
}
