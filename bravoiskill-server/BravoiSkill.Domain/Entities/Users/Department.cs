using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
