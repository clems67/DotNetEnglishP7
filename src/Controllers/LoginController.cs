using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/login")]
        public IActionResult Login(UserModel user)
        {
            var token = _userService.Login(user.userName, user.password).Result;
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }
            return Ok(token);
        }
    }
}