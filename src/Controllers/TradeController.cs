using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }
        [HttpPost("/trade/add")]
        public async Task CreateRating([FromBody] TradeModel trade)
        {
            await _tradeService.CreateTrade(trade);
        }

        [HttpGet("/trade/{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            TradeModel trades = await _tradeService.GetTrade(id);
            return Ok(trades);
        }

        [HttpPut("/trade/{id}")]
        public async Task UpdateRating([FromBody] TradeModel rating)
        {
            await _tradeService.UpdateTrade(rating);

        }

        [HttpDelete("/trade/{id}")]
        public async Task DeleteRating(int id)
        {
            await _tradeService.DeleteTrade(id);
        }
    }
}