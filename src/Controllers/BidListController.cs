using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    public class BidListController : Controller
    {
        private readonly IBidService _bidService;

        public BidListController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost("add")]
        public async Task CreateBid([FromBody]BidModel bid)
        {
            await _bidService.CreateBid(bid);
        }

        [HttpGet("/bidList/{id}")]
        public async Task<IActionResult> GetBid(int id)
        {
            BidModel bid = await _bidService.GetBid(id);
            return Ok(bid);
        }

        [HttpPut("{id}")]
        public async Task UpdateBid([FromBody] BidModel bid)
        {
            await(_bidService.UpdateBid(bid));
        }

        [HttpDelete("{id}")]
        public async Task DeleteBid(int id)
        {
            await (_bidService.DeleteBid(id));
        }
    }
}