using AutoMapper;
using BravoiSkill.Application.DTO.Users;
using BravoiSkill.Application.Services.Interfaces;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository _reviewRepository;
        private IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public IEnumerable<Review> GetAll()
        {
            var reviewsDb = _reviewRepository.GetListOfReviews();
            var reviewsDto = reviewsDb
                .Select(reviewDb => _mapper.Map<Review>(reviewDb))
                .ToList();

            return reviewsDto;
        }

        public IEnumerable<Review> GetAllFor(int id)
        {
            //var reviewsDb = _reviewRepository.GetListOfReviews().Where(x => x.ReviewedUserId == id);
            var reviewsDb = _reviewRepository.GetListOfReviewsFor(id);
            var reviewsDto = reviewsDb
                .Select(reviewDb => _mapper.Map<Review>(reviewDb))
                .ToList();

            return reviewsDto;
        }

        public Review GetById(int id)
        {
            var reviewDb = _reviewRepository.GetReviewById(id);
            return _mapper.Map<Review>(reviewDb);
        }

        public void Add(Review review)
        {
            var reviewDb = _mapper.Map<Domain.Entities.Users.Review>(review);
            _reviewRepository.AddReview(reviewDb);
        } 

        public void Create(Review review)
        {
            var reviewEntity = _mapper.Map<Domain.Entities.Users.Review>(review);
            _reviewRepository.Create(reviewEntity);
        }

        public async Task Edit(int id, Review review)
        {
            review.Validate();
            if (review.HasErrors)
                throw new Exception(review.Errors[0]);

            var reviewEntity = _reviewRepository.GetReviewById(id);
            if (reviewEntity == null)
                throw new Exception("Review does not exist in database");
            review.ReviewId = reviewEntity.ReviewId;

            _mapper.Map<Review, Domain.Entities.Users.Review>(review, reviewEntity);
            _reviewRepository.Update(reviewEntity);
        }

        public void Delete(int id)
        {
            var reviewEntity = _reviewRepository.GetReviewById(id);
            if (reviewEntity == null)
                throw new Exception("Review does not exist in database");

            _reviewRepository.Delete(reviewEntity);
        }
    }
}

