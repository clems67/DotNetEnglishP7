using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Interfaces;

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
