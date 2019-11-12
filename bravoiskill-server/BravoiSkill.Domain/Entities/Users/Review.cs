using System;
using System.ComponentModel.DataAnnotations;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        public string Comment { get; set; }

        public int ReviewedUserId { get; set; }
        public User ReviewedUser { get; set; }

        public int ReviewerUserId { get; set; }
        public User ReviewerUser { get; set; } 
    }
}
