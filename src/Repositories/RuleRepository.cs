using Dot.Net.WebApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class RuleRepository : IRuleRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RuleRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateRule(RuleModel rule)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Rule.Add(rule);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<RuleModel> FindByRuleId(int ruleId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Rule.Where(rule => rule.Id == ruleId)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateRule(RuleModel rule)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Rule.Update(rule);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRule(int ruleId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                RuleModel rule = dbContext.Rule.Find(ruleId);
                dbContext.Remove(rule);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
