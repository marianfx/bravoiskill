﻿using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Badge
    {
        [Key]
        public int BadgeId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
