using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class Skill: BaseDto
    {
        public int SkillId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public SkillCategory SkillCategory { get; set; }
    }
}
