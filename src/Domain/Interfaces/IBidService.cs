using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface IBidService
    {
        Task<BidModel> CreateBid(BidModel bid);
        Task<BidModel> GetBid(int bidId);
        Task<BidModel> UpdateBid(BidModel bid);
        Task<BidModel> DeleteBid(int bidId);
    }
}
