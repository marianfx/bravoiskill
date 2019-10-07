using BravoiSkill.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
    public interface ISkillRepository
    {

            /// <summary>
            ///     The method builds a query that selects all the skills from the Db
            /// </summary>
            /// <returns>The newly created Skill</returns>
            IQueryable<Domain.Entities.Users.Skill> GetListOfSkills();

            /// <summary>
            /// Searches for a skill based on skill ID. Returns null if not found
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            Skill GetSkillById(int id);

            Skill Create(Skill skill);

            Skill Update(Skill skill);

            void Delete(Skill skill);
        }
}
