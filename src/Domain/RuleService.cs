using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Controllers
{
    public class RuleService : IRuleService
    {
        public async Task<RuleModel> CreateRule(RuleModel rule)
        {
            return new RuleModel();
        }
        public async Task<RuleModel> GetRule(int ruleId)
        {
            return new RuleModel();
        }
        public async Task<RuleModel> UpdateRule(RuleModel rule)
        {
            return new RuleModel();
        }
        public async Task<RuleModel> DeleteRule(int ruleId)
        {
            return new RuleModel();
        }
    }
}