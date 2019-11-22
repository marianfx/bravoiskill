using BravoiSkill.Application.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<Skill> GetAll();

        Skill GetById(int id);

        IEnumerable<UserSkill> GetByUserId(int id);

        void Create(Skill skill);

        Task Edit(int id, Skill skill);

        void Delete(int id);
    }
}
