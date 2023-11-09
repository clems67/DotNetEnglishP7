using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task CreateRating(RatingModel rating);
        Task<RatingModel> FindByRatingId(int ratingId);
        Task UpdateRating(RatingModel rating);
        Task DeleteRating(int ratingId);
    }
}
