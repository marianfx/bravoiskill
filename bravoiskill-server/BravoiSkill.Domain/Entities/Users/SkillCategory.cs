using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ParentId { get; set; }
        public SkillCategory Skill_Category { get; set; }
    }
}
