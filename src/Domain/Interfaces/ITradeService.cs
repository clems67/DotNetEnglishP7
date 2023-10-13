using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface ITradeService
    {
        Task<TradeModel> CreateTrade(TradeModel trade);
        Task<TradeModel> GetTrade(int tradeId);
        Task<TradeModel> UpdateTrade(TradeModel trade);
        Task<TradeModel> DeleteTrade(int tradeId);
    }
}
