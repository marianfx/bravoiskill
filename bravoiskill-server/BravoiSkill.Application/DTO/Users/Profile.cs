using System.Collections.Generic;

namespace BravoiSkill.Domain.Entities.Users
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Description { get; set; }

        public string[] Validate()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(Description))
                errors.Add("Description must be provided");
            return errors.ToArray();
        }
    }
}
