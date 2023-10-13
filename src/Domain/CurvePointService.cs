using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class CurvePointService : ICurvePointService
    {
        public async Task<CurvePointModel> CreateCurevePoint(CurvePointModel curvePoint)
        {
            return new CurvePointModel();
        }

        public async Task<CurvePointModel> DeleteCurevePoint(int curvePointId)
        {
            return new CurvePointModel();
        }

        public async Task<CurvePointModel> GetCurevePoint(int curvePointId)
        {
            return new CurvePointModel();
        }

        public async Task<CurvePointModel> UpdateCurevePoint(CurvePointModel bid)
        {
            return new CurvePointModel();
        }
    }
}