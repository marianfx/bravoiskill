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

        IEnumerable<Review> GetAllFor(int id);

        Review GetById(int id);

        void Add(Review review);

        void Create(Review review);

        Task Edit(int id, Review review);

        void Delete(int id);
    }
}
