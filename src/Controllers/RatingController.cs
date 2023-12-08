using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpPost("/rating/add")]
        public async Task Create([FromBody] RatingModel rating)
        {
            await _ratingService.CreateRating(rating);
        }

        [Authorize]
        [HttpGet("/rating/{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            RatingModel ratings = await _ratingService.GetRating(id);
            return Ok(ratings);
        }

        [Authorize]
        [HttpPut("/rating/{id}")]
        public async Task UpdateRating([FromBody] RatingModel rating)
        {
            await _ratingService.UpdateRating(rating);
        }

        [Authorize]
        [HttpDelete("/rating/{id}")]
        public async Task DeleteRating(int id)
        {
            await _ratingService.DeleteRating(id);
        }
    }
}