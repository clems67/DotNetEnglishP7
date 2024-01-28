using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Test
{
    public class TradeTest
    {
        [Fact]
        public async Task GetTrade()
        {
            //ARRANGE
            var tradeId = 1;
            var mockRepo = new Mock<ITradeRepository>();
            var service = new TradeService(mockRepo.Object);
            mockRepo.Setup(repo => repo.FindByTradeId(It.IsAny<int>()))
                .ReturnsAsync(new TradeModel());
            //ACT
            var trade = await service.GetTrade(tradeId);
            //ASSERT
            Assert.IsType<TradeModel>(trade);
            mockRepo.Verify(mock => mock.FindByTradeId(tradeId), Times.Once());
        }
        [Fact]
        public async Task CreateTrade()
        {
            //ARRANGE
            var trade = new TradeModel();
            var mockRepo = new Mock<ITradeRepository>();
            var service = new TradeService(mockRepo.Object);
            mockRepo.Setup(repo => repo.CreateTrade(It.IsAny<TradeModel>()));
            //ACT
            await service.CreateTrade(trade);
            //ASSERT
            mockRepo.Verify(mock => mock.CreateTrade(trade), Times.Once());
        }
        [Fact]
        public async Task UpdateTrade()
        {
            //ARRANGE
            var trade = new TradeModel();
            var mockRepo = new Mock<ITradeRepository>();
            var service = new TradeService(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateTrade(It.IsAny<TradeModel>()));
            //ACT
            await service.UpdateTrade(trade);
            //ASSERT
            mockRepo.Verify(mock => mock.UpdateTrade(trade), Times.Once());
        }
        [Fact]
        public async Task DeleteTrade()
        {
            //ARRANGE
            var tradeId = 1;
            var mockRepo = new Mock<ITradeRepository>();
            var service = new TradeService(mockRepo.Object);
            mockRepo.Setup(repo => repo.DeleteTrade(It.IsAny<int>()));
            //ACT
            await service.DeleteTrade(1);
            //ASSERT
            mockRepo.Verify(mock => mock.DeleteTrade(tradeId), Times.Once());
        }
    }
}
