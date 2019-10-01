using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BravoiSkill.Domain.Entities.Users
{
    public class SkillCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public SkillCategory Parent { get; set; }

        public ICollection<SkillCategory> Children { get; set; }
    }
}
