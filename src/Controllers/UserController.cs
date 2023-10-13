using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("/rating/add")]
        public async Task<IActionResult> CreateRating([FromBody] UserModel user)
        {
            UserModel users = await _userService.CreateUser(user);
            return Ok(users);
        }

        [HttpGet("/rating/{id}")]
        public async Task<IActionResult> GetRating(int id)
        {
            UserModel users = await _userService.GetUser(id);
            return Ok(users);
        }

        [HttpPut("/rating/{id}")]
        public async Task<IActionResult> UpdateRating([FromBody] UserModel rating)
        {
            UserModel users = await _userService.UpdateUser(rating);
            return Ok(users);
        }

        [HttpDelete("/rating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            UserModel users = await _userService.DeleteUser(id);
            return Ok(users);
        }
    }
}