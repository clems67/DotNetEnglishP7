using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Controllers
{
    public class RuleController : Controller
    {
        private readonly IRuleService _ruleService;
        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        [HttpPost("/rule/add")]
        public async Task<IActionResult> CreateRule([FromBody] RuleModel rule)
        {
            RuleModel rules = await _ruleService.CreateRule(rule);
            return Ok(rules);
        }

        [HttpGet("/ruleList/{id}")]
        public async Task<IActionResult> GetRule(int id)
        {
            RuleModel rule = await _ruleService.GetRule(id);
            return Ok(rule);
        }

        [HttpPut("/rule/{id}")]
        public async Task<IActionResult> UpdateRule([FromBody] RuleModel rule)
        {
            RuleModel rules = await (_ruleService.UpdateRule(rule));
            return Ok(rules);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            RuleModel rules = await (_ruleService.DeleteRule(id));
            return Ok(rules);
        }
    }
}