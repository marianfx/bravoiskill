using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BravoiSkill.Infrastructure.Repositories.Users
{
    public class ReviewRepository : IReviewRepository
    {
        private BravoiSkillDbContext _context;

        public ReviewRepository(BravoiSkillDbContext context)
        {
            _context = context;
        }

        public IQueryable<Review> GetListOfReviews()
        {
            var rez = from d in _context.Reviews
                      select d;
            return rez;
        }

        public IQueryable<Review> GetListOfReviewsFor(int id)
        {
            var rez = _context.Reviews
                .Where(d => d.ReviewedUserId == id)
                .Include(s => s.ReviewSkills)
                .ThenInclude(s => s.Skill)
                .Include(s => s.ReviewerUser);
            return rez;
        }

        public Review GetReviewById(int id)
        {
            var rez = from d in _context.Reviews
                      where d.ReviewId == id
                      select d;
            return rez.FirstOrDefault();
        }

        public Review Create(Review review)
        {
            _context.Set<Review>().Add(review);
            _context.SaveChanges();
            return review;
        }

        public Review Update(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
            return review;
        }

        public void Delete(Review review)
        {
            _context.Set<Review>().Remove(review);
            _context.SaveChanges();
        }

        public void AddReview(Review review)
        {
            // declare transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // validari => exception
                    if (review != null)
                    {
                        // transaction 
                        _context.Set<Review>().Add(review);
                        _context.SaveChanges();
                        // commit transaction

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // rollback transaction
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}


