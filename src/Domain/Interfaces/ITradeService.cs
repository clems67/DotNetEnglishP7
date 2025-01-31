﻿using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface ITradeService
    {
        Task CreateTrade(TradeModel trade);
        Task<TradeModel> GetTrade(int tradeId);
        Task UpdateTrade(TradeModel trade);
        Task DeleteTrade(int tradeId);
    }
}
