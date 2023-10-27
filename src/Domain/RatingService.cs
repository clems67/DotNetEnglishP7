using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace WebApi.Domain
{
    public class RatingService : IRatingService
    {
        public async Task<RatingModel> CreateRating(RatingModel rating)
        {
            return new RatingModel();
        }

        public async Task<RatingModel> DeleteRating(int ratingId)
        {
            return new RatingModel();
        }

        public async Task<RatingModel> GetRating(int ratingId)
        {
            return new RatingModel();
        }

        public async Task<RatingModel> UpdateRating(RatingModel rating)
        {
            return new RatingModel();
        }
    }
}
