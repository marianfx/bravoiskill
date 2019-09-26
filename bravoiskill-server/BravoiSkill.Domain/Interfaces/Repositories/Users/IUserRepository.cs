using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
   public interface IUserRepository
    {
        /// <summary>
        ///     The method builds a query that selects all the users from the Db
        /// </summary>
        /// <returns></returns>
        IQueryable<Domain.Entities.Users.User> GetListOfUsers();
    }
}
