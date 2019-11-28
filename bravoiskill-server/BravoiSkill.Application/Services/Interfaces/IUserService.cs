using BravoiSkill.Application.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetUsersReviewersByUserId(int id);

        User GetById(int id);

        void Create(User user);

        Task Edit(int id, User user);

        void Delete(int id);
    }   
}
