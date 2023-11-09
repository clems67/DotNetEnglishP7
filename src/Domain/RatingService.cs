using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Domain
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task CreateRating(RatingModel rating)
        {
            await _ratingRepository.CreateRating(rating);
        }

        public async Task<RatingModel> GetRating(int ratingId)
        {
            return await _ratingRepository.FindByRatingId(ratingId);
        }

        public async Task UpdateRating(RatingModel rating)
        {
            await _ratingRepository.UpdateRating(rating);
        }

        public async Task DeleteRating(int ratingId)
        {
            await _ratingRepository.DeleteRating(ratingId);
        }
    }
}
