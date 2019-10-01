using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillLargeCategory
    {
        [Key]
        public int LargeCategoryId { get; set; }
        public string Description { get; set; }
    }
}
