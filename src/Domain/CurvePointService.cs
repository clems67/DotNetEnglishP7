using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;
        public CurvePointService(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }
        public async Task CreateCurevePoint(CurvePointModel curvePoint)
        {
            await _curvePointRepository.CreateCurvePoint(curvePoint);
        }

        public async Task<CurvePointModel> GetCurevePoint(int curvePointId)
        {
            return await _curvePointRepository.FindByCurvePointId(curvePointId);
        }

        public async Task UpdateCurevePoint(CurvePointModel curvePoint)
        {
            await _curvePointRepository.UpdateCurvePoint(curvePoint);
        }

        public async Task DeleteCurevePoint(int curvePointId)
        {
            await _curvePointRepository.DeleteCurvePoint(curvePointId);
        }
    }
}