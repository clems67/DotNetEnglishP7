using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public async Task CreateBid(BidModel bid)
        {
            await _bidRepository.CreateBid(bid);
        }
        public async Task<BidModel> GetBid(int bidId)
        {
            return await _bidRepository.FindByBidId(bidId);
        }
        public async Task UpdateBid(BidModel bid)
        {
            await _bidRepository.UpdateBid(bid);
        }
        public async Task DeleteBid(int bidId)
        {
            await _bidRepository.DeleteBid(bidId);
        }
    }
}