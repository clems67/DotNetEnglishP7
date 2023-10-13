using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface IRatingService
    {
        Task<RatingModel> CreateRating(RatingModel rating);
        Task<RatingModel> GetRating(int ratingId);
        Task<RatingModel> UpdateRating(RatingModel rating);
        Task<RatingModel> DeleteRating(int ratingId);
    }
}
