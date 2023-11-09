using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task CreateBid(BidModel bid);
        Task<BidModel> FindByBidId(int bidId);
        Task UpdateBid(BidModel bid);
        Task DeleteBid(int bidId);
    }
}
