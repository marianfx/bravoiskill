using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BravoiSkill.Domain.Entities.Users
{
    public class UserBadge
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}
