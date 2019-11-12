using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillReview
    {
        [Required]
        public int ReviewPoints { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
