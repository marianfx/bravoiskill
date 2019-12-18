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

        IQueryable<Review> GetListOfReviewsFor(int id);

        Review GetReviewById(int id);
        void AddReview(Review review);

        Review Create(Review review);

        Review Update(Review review);

        void Delete(Review review);
    }
}
