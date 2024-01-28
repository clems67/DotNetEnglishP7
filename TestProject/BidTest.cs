using Dot.Net.WebApi.Domain;
using Moq;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace TestProject
{
    public class BidTest
    {
        [Fact]
        public async Task GetBid()
        {
            //ARRANGE
            var bidId = 1;
            var mockRepo = new Mock<IBidRepository>();
            var service = new BidService(mockRepo.Object);
            mockRepo.Setup(repo => repo.FindByBidId(It.IsAny<int>()))
                .ReturnsAsync(new BidModel());
            //ACT
            var bid = await service.GetBid(bidId);
            //ASSERT
            Assert.IsType<BidModel>(bid);
            mockRepo.Verify(mock => mock.FindByBidId(bidId), Times.Once());
        }
        [Fact]
        public async Task CreateBid()
        {
            //ARRANGE
            var bid = new BidModel();
            var mockRepo = new Mock<IBidRepository>();
            var service = new BidService(mockRepo.Object);
            mockRepo.Setup(repo => repo.CreateBid(It.IsAny<BidModel>()));
            //ACT
            await service.CreateBid(bid);
            //ASSERT
            mockRepo.Verify(mock => mock.CreateBid(bid), Times.Once());
        }
        [Fact]
        public async Task UpdateBid()
        {
            //ARRANGE
            var bid = new BidModel();
            var mockRepo = new Mock<IBidRepository>();
            var service = new BidService(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateBid(It.IsAny<BidModel>()));
            //ACT
            await service.UpdateBid(bid);
            //ASSERT
            mockRepo.Verify(mock => mock.UpdateBid(bid), Times.Once());
        }
        [Fact]
        public async Task DeleteBid()
        {
            //ARRANGE
            var bidId = 1;
            var mockRepo = new Mock<IBidRepository>();
            var service = new BidService(mockRepo.Object);
            mockRepo.Setup(repo => repo.DeleteBid(It.IsAny<int>()));
            //ACT
            await service.DeleteBid(1);
            //ASSERT
            mockRepo.Verify(mock => mock.DeleteBid(bidId), Times.Once());
        }
    }
}