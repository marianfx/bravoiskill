using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
