using Dot.Net.WebApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TradeRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateTrade(TradeModel trade)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Trade.Add(trade);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<TradeModel> FindByTradeId(int tradeId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Trade.Where(trade => trade.Id == tradeId)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateTrade(TradeModel trade)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Trade.Update(trade);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTrade(int tradeId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                TradeModel trade = dbContext.Trade.Find(tradeId);
                dbContext.Remove(trade);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
