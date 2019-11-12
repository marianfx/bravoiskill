using System;
using System.Collections.Generic;
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

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int BadgeId { get; set; }
        public Badge Badge { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserBadge> UserBadges { get; set; }
        public virtual ICollection<Review> ReviewedReviews { get; set; }
        public virtual ICollection<Review> ReviewerReviews { get; set; }
    }
}
