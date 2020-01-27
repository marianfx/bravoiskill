using BravoiSkill.Application.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IBadgeService
   {
        IEnumerable<Badge> GetAll();

        IEnumerable<Badge> GetAllFor(int id);

        Badge GetActiveBadgeById(int id);

        void Create(Badge badge);

        Task Edit(int id, Badge badge);

        void Delete(int id);
   }
}
