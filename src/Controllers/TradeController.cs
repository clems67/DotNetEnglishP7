using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using WebApi.Domain.Interfaces;

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
        [HttpPost("/rating/add")]
        public async Task<IActionResult> CreateRating([FromBody] TradeModel trade)
        {
            TradeModel trades = await _tradeService.CreateTrade(trade);
            return Ok(trades);
        }

        [HttpGet("/rating/{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            TradeModel trades = await _tradeService.GetTrade(id);
            return Ok(trades);
        }

        [HttpPut("/rating/{id}")]
        public async Task<IActionResult> UpdateRating([FromBody] TradeModel rating)
        {
            TradeModel trades = await _tradeService.UpdateTrade(rating);
            return Ok(trades);
        }

        [HttpDelete("/rating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            TradeModel trades = await _tradeService.DeleteTrade(id);
            return Ok(trades);
        }
    }
}