using Dot.Net.WebApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CurvePointRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task CreateCurvePoint(CurvePointModel curvePoint)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.CurvePoint.Add(curvePoint);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<CurvePointModel> FindByCurvePointId(int curvePointId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.CurvePoint.Where(curvePoint => curvePoint.ID == curvePointId)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateCurvePoint(CurvePointModel curvePoint)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.CurvePoint.Update(curvePoint);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCurvePoint(int curvePointId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                CurvePointModel curvePoint = dbContext.CurvePoint.Find(curvePointId);
                dbContext.Remove(curvePoint);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
