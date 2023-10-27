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
        public async Task<IActionResult> CreateBid([FromBody]BidModel bid)
        {
            BidModel bids = await _bidService.CreateBid(bid);
            return Ok(bids);
        }

        [HttpGet("/bidList/{id}")]
        public async Task<IActionResult> GetBid(int id)
        {
            BidModel bid = await _bidService.GetBid(id);
            return Ok(bid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid([FromBody] BidModel bid)
        {
           BidModel bids = await(_bidService.UpdateBid(bid));
            return Ok(bids);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            BidModel bids = await (_bidService.DeleteBid(id));
            return Ok(bids);
        }
    }
}