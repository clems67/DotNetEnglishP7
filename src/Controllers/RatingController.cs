using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpPost("/rating/add")]
        public async Task<IActionResult> Create([FromBody] RatingModel rating)
        {
            RatingModel ratings = await _ratingService.CreateRating(rating);
            return Ok(ratings);
        }

        [HttpGet("/rating/{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            RatingModel ratings = await _ratingService.GetRating(id);
            return Ok(ratings);
        }

        [HttpPut("/rating/{id}")]
        public async Task<IActionResult> UpdateRating([FromBody] RatingModel rating)
        {
            RatingModel ratings = await _ratingService.UpdateRating(rating);
            return Ok(ratings);
        }

        [HttpDelete("/rating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            RatingModel ratings = await _ratingService.DeleteRating(id);
            return Ok(ratings);
        }
    }
}