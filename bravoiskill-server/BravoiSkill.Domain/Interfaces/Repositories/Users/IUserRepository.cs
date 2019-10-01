using BravoiSkill.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
   public interface IUserRepository
    {
        /// <summary>
        ///     The method builds a query that selects all the users from the Db
        /// </summary>
        /// <returns>The newly created user</returns>
        IQueryable<Domain.Entities.Users.User> GetListOfUsers();
        User Create(Entities.Users.User user);

        User Update(User user);

        Task<User> GetUserById(int Id);
    }
}
