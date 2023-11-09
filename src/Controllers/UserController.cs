using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

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
        [HttpPost("/user/add")]
        public async Task CreateUser([FromBody] UserModel user)
        {
            await _userService.CreateUser(user);
        }

        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            UserModel users = await _userService.GetUser(id);
            return Ok(users);
        }

        [HttpPut("/user/{id}")]
        public async Task UpdateUser(UserModel user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpDelete("/user/{id}")]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }
    }
}