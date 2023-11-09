using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface ICurvePointService
    {
        Task CreateCurevePoint(CurvePointModel curvePoint);
        Task<CurvePointModel> GetCurevePoint(int curvePointId);
        Task UpdateCurevePoint(CurvePointModel curvePoint);
        Task DeleteCurevePoint(int curvePointId);
    }
}
