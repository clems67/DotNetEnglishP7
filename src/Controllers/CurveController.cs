using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class CurveController : Controller
    {
        private readonly ICurvePointService _curveService;

        public CurveController(ICurvePointService curveService)
        {
            _curveService = curveService;
        }

        [Authorize]
        [HttpPost("/curvePoint/add")]
        public async Task CreateCurvePoint([FromBody]CurvePointModel curvePoint)
        {
            await _curveService.CreateCurevePoint(curvePoint);
        }

        [Authorize]
        [HttpGet("/curvePoint/{id}")]
        public async Task<IActionResult> GetCurvePoint(int id)
        {
            CurvePointModel curvePoint = await _curveService.GetCurevePoint(id);
            return Ok(curvePoint);
        }

        [Authorize]
        [HttpPut("/curvePoint/{id}")]
        public async Task UpdateCurvePoint([FromBody] CurvePointModel curvePoint)
        {
            await _curveService.UpdateCurevePoint(curvePoint);
        }

        [Authorize]
        [HttpDelete("/curvePoint/{id}")]
        public async Task DeleteCurvePoint(int id)
        {
            await _curveService.DeleteCurevePoint(id);
        }
    }
}