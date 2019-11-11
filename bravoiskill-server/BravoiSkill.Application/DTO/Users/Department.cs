using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class Department: BaseDto
    {
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
