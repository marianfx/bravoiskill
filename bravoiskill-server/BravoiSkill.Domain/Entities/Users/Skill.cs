using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public ICollection<UserSkill> SkillUsers { get; set; }
    }
}
