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
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
