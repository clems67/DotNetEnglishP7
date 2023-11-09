using Dot.Net.WebApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RatingRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateRating(RatingModel rating)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Rating.Add(rating);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<RatingModel> FindByRatingId(int ratingId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Rating.Where(rating => rating.Id == ratingId)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateRating(RatingModel rating)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Rating.Update(rating);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRating(int ratingId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                RatingModel rating = dbContext.Rating.Find(ratingId);
                dbContext.Remove(rating);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
