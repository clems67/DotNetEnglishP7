using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class TradeService : ITradeService
    {
        public async Task<TradeModel> CreateTrade(TradeModel trade)
        {
            return new TradeModel();
        }

        public async Task<TradeModel> DeleteTrade(int tradeId)
        {
            return new TradeModel();
        }

        public async Task<TradeModel> GetTrade(int tradeId)
        {
            return new TradeModel();
        }

        public async Task<TradeModel> UpdateTrade(TradeModel trade)
        {
            return new TradeModel();
        }
    }
}