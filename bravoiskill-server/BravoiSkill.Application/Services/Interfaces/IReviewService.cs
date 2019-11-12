using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAll();

        Review GetById(int id);

        void Create(Review review);

        Task Edit(int id, Review review);

        void Delete(int id);
    }
}
