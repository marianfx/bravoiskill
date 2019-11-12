using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class Badge: BaseDto
    {
        public int BadgeId { get; set; }
        public string Description { get; set; }
    }
}
