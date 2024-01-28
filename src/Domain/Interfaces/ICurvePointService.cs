using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface ICurvePointService
    {
        Task CreateCurvePoint(CurvePointModel curvePoint);
        Task<CurvePointModel> GetCurvePoint(int curvePointId);
        Task UpdateCurvePoint(CurvePointModel curvePoint);
        Task DeleteCurvePoint(int curvePointId);
    }
}
