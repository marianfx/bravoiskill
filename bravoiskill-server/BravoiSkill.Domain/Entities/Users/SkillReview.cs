using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillReview
    {
        [Required]
        public int ReviewPoints { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
