using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Controllers
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepository;
        public RuleService(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }
        public async Task CreateRule(RuleModel rule)
        {
            await _ruleRepository.CreateRule(rule);
        }
        public async Task<RuleModel> GetRule(int ruleId)
        {
            return await _ruleRepository.FindByRuleId(ruleId);
        }
        public async Task UpdateRule(RuleModel rule)
        {
            await _ruleRepository.UpdateRule(rule);
        }
        public async Task DeleteRule(int ruleId)
        {
            await _ruleRepository.DeleteRule(ruleId);
        }
    }
}