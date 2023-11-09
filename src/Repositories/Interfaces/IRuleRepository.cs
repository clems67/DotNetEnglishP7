using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IRuleRepository
    {
        Task CreateRule(RuleModel rule);
        Task<RuleModel> FindByRuleId(int ruleId);
        Task UpdateRule(RuleModel rule);
        Task DeleteRule(int ruleId);
    }
}
