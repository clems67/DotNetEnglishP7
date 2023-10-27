using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;

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