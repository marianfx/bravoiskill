using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
