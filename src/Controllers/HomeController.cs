using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Ok();
        }
        [HttpGet("/error")]
        public IActionResult Error()
        {
            throw new NotImplementedException();
        }
    }
}