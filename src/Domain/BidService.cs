using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;

namespace Dot.Net.WebApi.Domain
{
    public class BidService : IBidService
    {
        public async Task<BidModel> CreateBid(BidModel bid)
        {
            return new BidModel();
        }
        public async Task<BidModel> GetBid(int bidId)
        {
            return new BidModel();
        }
        public async Task<BidModel> UpdateBid(BidModel bid)
        {
            return new BidModel();
        }
        public async Task<BidModel> DeleteBid(int bidId)
        {
            return new BidModel();
        }
    }
}