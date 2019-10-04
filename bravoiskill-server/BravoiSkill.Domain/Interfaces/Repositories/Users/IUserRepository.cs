using BravoiSkill.Domain.Entities.Users;
using System.Linq;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
   public interface IUserRepository
    {
        /// <summary>
        ///     The method builds a query that selects all the users from the Db
        /// </summary>
        /// <returns>The newly created user</returns>
        IQueryable<Domain.Entities.Users.User> GetListOfUsers();

        /// <summary>
        /// Searches for an user based on user ID. Returns null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);

        User Create(User user);

        User Update(User user);

        void Delete(User user);
    }
}
