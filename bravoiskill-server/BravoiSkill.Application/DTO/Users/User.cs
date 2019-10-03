using BravoiSkill.Application.DTO.Shared;
using System;
using System.Collections.Generic;

namespace BravoiSkill.Application.DTO.Users
{
    public class User: BaseDto
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
        public int DepartmentId { get; set; }

        public override IList<string> Validate()
        {
            Errors = new List<string>();
            if (string.IsNullOrWhiteSpace(FirstName))
                Errors.Add(nameof(FirstName) + " cannot be empty");
            else if (string.IsNullOrWhiteSpace(LastName))
                Errors.Add(nameof(LastName) + " cannot be empty");
            else if (string.IsNullOrWhiteSpace(Email))
                Errors.Add(nameof(Email) + " cannot be empty");
            else if (DateOfBirth == null)
                Errors.Add(nameof(DateOfBirth) + " cannot be empty");
            return Errors;
        }
    }
}
