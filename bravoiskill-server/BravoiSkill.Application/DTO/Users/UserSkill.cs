using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class UserSkill: BaseDto
    {
        public int Points { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
