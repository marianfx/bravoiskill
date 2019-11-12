using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class SkillReview: BaseDto
    {
        public int ReviewPoints { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
