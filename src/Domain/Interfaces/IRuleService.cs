using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface IRuleService
    {
        Task CreateRule(RuleModel rule);
        Task<RuleModel> GetRule(int ruleId);
        Task UpdateRule (RuleModel rule);
        Task DeleteRule(int ruleId);
    }
}
