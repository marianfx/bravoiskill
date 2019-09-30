using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillSmallCategory
    {
        [Key]
        public int SmallCategoryId { get; set; }
        public string Description { get; set; }

        public int LargeCategoryId { get; set; }
        public SkillLargeCategory SkillLargeCategory { get; set; }
    }
}
