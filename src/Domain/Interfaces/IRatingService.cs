﻿using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface IRatingService
    {
        Task CreateRating(RatingModel rating);
        Task<RatingModel> GetRating(int ratingId);
        Task UpdateRating(RatingModel rating);
        Task DeleteRating(int ratingId);
    }
}
