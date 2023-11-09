using Dot.Net.WebApi.Repositories;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task CreateTrade(TradeModel trade)
        {
            await _tradeRepository.CreateTrade(trade);
        }

        public async Task<TradeModel> GetTrade(int tradeId)
        {
            return await _tradeRepository.FindByTradeId(tradeId);
        }

        public async Task DeleteTrade(int tradeId)
        {
            await _tradeRepository.DeleteTrade(tradeId);
        }

        public async Task UpdateTrade(TradeModel trade)
        {
            await _tradeRepository.UpdateTrade(trade);
        }
    }
}