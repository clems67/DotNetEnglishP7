using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
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
        [HttpPost("/curvePoint/add")]
        public async Task<IActionResult> CreateCurvePoint([FromBody]CurvePointModel curvePoint)
        {
            CurvePointModel curvePoints = await _curveService.CreateCurevePoint(curvePoint);
            return Ok(curvePoints);
        }

        [HttpGet("/curvePoint/{id}")]
        public async Task<IActionResult> GetCurvePoint(int id)
        {
            CurvePointModel curvePoint = await _curveService.GetCurevePoint(id);
            return Ok(curvePoint);
        }

        [HttpPut("/curvePoint/{id}")]
        public async Task<IActionResult> UpdateCurvePoint([FromBody] CurvePointModel curvePoint)
        {
            CurvePointModel curvePoints = await _curveService.UpdateCurevePoint(curvePoint);
            return Ok(curvePoints);
        }

        [HttpDelete("/curvePoint/{id}")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            CurvePointModel curvePoints = await _curveService.DeleteCurevePoint(id);
            return Ok(curvePoints);
        }
    }
}