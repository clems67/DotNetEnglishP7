using Dot.Net.WebApi.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Test
{
public class RatingTest
    {
        [Fact]
        public async Task GetRating()
        {    
            //ARRANGE
            var ratingId = 1;
            var mockRepo = new Mock<IRatingRepository>();
            var service = new RatingService(mockRepo.Object);
            mockRepo.Setup(repo => repo.FindByRatingId(It.IsAny<int>()))
                .ReturnsAsync(new RatingModel());
            //ACT
            var rating = await service.GetRating(ratingId);
            //ASSERT
            Assert.IsType<RatingModel>(rating);
            mockRepo.Verify(mock => mock.FindByRatingId(ratingId), Times.Once());
        }
        [Fact]
        public async Task CreateRating()
        {
            //ARRANGE
            var rating = new RatingModel();
            var mockRepo = new Mock<IRatingRepository>();
            var service = new RatingService(mockRepo.Object);
            mockRepo.Setup(repo => repo.CreateRating(It.IsAny<RatingModel>()));
            //ACT
            await service.CreateRating(rating);
            //ASSERT
            mockRepo.Verify(mock => mock.CreateRating(rating), Times.Once());
        }
        [Fact]
        public async Task UpdateRating()
        {
            //ARRANGE
            var rating = new RatingModel();
            var mockRepo = new Mock<IRatingRepository>();
            var service = new RatingService(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateRating(It.IsAny<RatingModel>()));
            //ACT
            await service.UpdateRating(rating);
            //ASSERT
            mockRepo.Verify(mock => mock.UpdateRating(rating), Times.Once());
        }
        [Fact]
        public async Task DeleteRating()
        {
            //ARRANGE
            var ratingId = 1;
            var mockRepo = new Mock<IRatingRepository>();
            var service = new RatingService(mockRepo.Object);
            mockRepo.Setup(repo => repo.DeleteRating(It.IsAny<int>()));
            //ACT
            await service.DeleteRating(1);
            //ASSERT
            mockRepo.Verify(mock => mock.DeleteRating(ratingId), Times.Once());
        }
    }
}
