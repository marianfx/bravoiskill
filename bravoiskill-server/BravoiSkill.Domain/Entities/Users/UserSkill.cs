using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BravoiSkill.Domain.Entities.Users
{
    public class UserSkill
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Points { get; set; }
    }
}
