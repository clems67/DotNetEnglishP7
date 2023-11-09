using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface ICurvePointRepository
    {
        Task CreateCurvePoint(CurvePointModel curvePoint);
        Task<CurvePointModel> FindByCurvePointId(int curvePointId);
        Task UpdateCurvePoint(CurvePointModel curvePoint);
        Task DeleteCurvePoint(int curvePointId);
    }
}
