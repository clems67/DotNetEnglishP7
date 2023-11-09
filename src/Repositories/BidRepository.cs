using Dot.Net.WebApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BidRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateBid(BidModel bid)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Bid.Add(bid);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BidModel> FindByBidId(int bidId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Bid.Where(bid => bid.Id == bidId)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateBid(BidModel bid)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Bid.Update(bid);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBid(int bidId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                BidModel bid = dbContext.Bid.Find(bidId);
                dbContext.Remove(bid);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
