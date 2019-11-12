using BravoiSkill.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
   public interface IReviewRepository
    {
        IQueryable<Review> GetListOfReviews();

        Review GetReviewById(int id);

        Review Create(Review review);

        Review Update(Review review);

        void Delete(Review review);
    }
}
