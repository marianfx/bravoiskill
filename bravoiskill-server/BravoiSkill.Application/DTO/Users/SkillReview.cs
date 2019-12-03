using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class SkillReview: BaseDto
    {
        public int ReviewPoints { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int ReviewId { get; set; }
    }
}
