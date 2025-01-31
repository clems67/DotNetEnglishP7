﻿using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface IBidService
    {
        Task CreateBid(BidModel bid);
        Task<BidModel> GetBid(int bidId);
        Task UpdateBid(BidModel bid);
        Task DeleteBid(int bidId);
    }
}
