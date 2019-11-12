using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        public string Comment { get; set; }

        [Required]
        public int ReviewedUserId { get; set; }
        [Required]
        public int ReviewerUserId { get; set; }

        [ForeignKey("ReviewedUserId")]
        public User ReviewedUser { get; set; }

        [ForeignKey("ReviewerUserId")]
        public User ReviewerUser { get; set; }

        public ICollection<SkillReview> ReviewSkills { get; set; }
    }
}
