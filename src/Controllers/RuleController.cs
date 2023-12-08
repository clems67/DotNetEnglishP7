using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    public class RuleController : Controller
    {
        private readonly IRuleService _ruleService;
        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        [Authorize]
        [HttpPost("/rule/add")]
        public async Task CreateRule([FromBody] RuleModel rule)
        {
            await _ruleService.CreateRule(rule);
        }

        [Authorize]
        [HttpGet("/ruleList/{id}")]
        public async Task<IActionResult> GetRule(int id)
        {
            RuleModel rule = await _ruleService.GetRule(id);
            return Ok(rule);
        }

        [Authorize]
        [HttpPut("/rule/{id}")]
        public async Task UpdateRule([FromBody] RuleModel rule)
        {
            await (_ruleService.UpdateRule(rule));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteRule(int id)
        {
            await (_ruleService.DeleteRule(id));
        }
    }
}