using System;
using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Skype { get; set; }
        public string Photo { get; set; }
        [Required]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}
