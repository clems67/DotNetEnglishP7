using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task CreateTrade(TradeModel trade);
        Task<TradeModel> FindByTradeId(int tradeId);
        Task UpdateTrade(TradeModel trade);
        Task DeleteTrade(int tradeId);
    }
}
