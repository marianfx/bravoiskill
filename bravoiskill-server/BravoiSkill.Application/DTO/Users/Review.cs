using System;
using System.Collections.Generic;
using BravoiSkill.Application.DTO.Shared;

namespace BravoiSkill.Application.DTO.Users
{
    public class Review : BaseDto
    {
        public int ReviewId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Comment { get; set; }
        public int ReviewedUserId { get; set; }
        public int ReviewerUserId { get; set; }
        public User ReviewerUser { get; set; }
        
        public IList<SkillReview> ReviewSkills { get; set; }
    }
}
