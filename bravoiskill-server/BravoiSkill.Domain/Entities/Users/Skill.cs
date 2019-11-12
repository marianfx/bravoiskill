using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
        
        public ICollection<UserSkill> SkillUsers { get; set; }
        public ICollection<SkillReview> SkillReviews { get; set; }
    }
}
