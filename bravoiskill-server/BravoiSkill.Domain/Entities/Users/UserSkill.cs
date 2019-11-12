﻿using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class UserSkill
    {
        [Required]
        public int Points { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
