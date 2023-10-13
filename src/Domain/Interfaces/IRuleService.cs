using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface IRuleService
    {
        Task<RuleModel> CreateRule(RuleModel rule);
        Task<RuleModel> GetRule(int ruleId);
        Task<RuleModel> UpdateRule (RuleModel rule);
        Task<RuleModel> DeleteRule(int ruleId);
    }
}
