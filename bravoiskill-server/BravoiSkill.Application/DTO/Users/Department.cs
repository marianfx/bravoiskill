using BravoiSkill.Application.DTO.Shared;
using System;
using System.Collections.Generic;

namespace BravoiSkill.Application.DTO.Users
{
    public class Department: BaseDto
    {
        public int DepartmentId { get; set; }
        public string Description { get; set; }
       
    }
}
