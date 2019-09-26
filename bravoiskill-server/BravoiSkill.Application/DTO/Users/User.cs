using System;
using System.Collections.Generic;
using System.Text;

namespace BravoiSkill.Application.DTO.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Skype { get; set; }
        public string Photo { get; set; }
        public int ProfileId { get; set; }
        public int BadgeId { get; set; }
        public string Token { get; set; }
    }
}
