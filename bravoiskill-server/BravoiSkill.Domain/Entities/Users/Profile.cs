using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string Description { get; set; }
    }
}
