
using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface ISkillService
    {
       
        IEnumerable<Skill> GetAll();
        Skill GetById(int id);

        void Create(Skill skill);

        Task Edit(int id, Skill skill);

        void Delete(int id);
    }
}
