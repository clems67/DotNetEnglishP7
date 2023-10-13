using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface ICurvePointService
    {
        Task<CurvePointModel> CreateCurevePoint(CurvePointModel curvePoint);
        Task<CurvePointModel> GetCurevePoint(int curvePointId);
        Task<CurvePointModel> UpdateCurevePoint(CurvePointModel curvePoint);
        Task<CurvePointModel> DeleteCurevePoint(int curvePointId);
    }
}
