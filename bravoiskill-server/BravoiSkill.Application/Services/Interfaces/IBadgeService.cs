using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
   public interface IBadgeService
    {
        IEnumerable<Badge> GetAll();

        Badge GetById(int id);

        void Create(Badge badge);

        Task Edit(int id, Badge badge);

        void Delete(int id);
    }
}
