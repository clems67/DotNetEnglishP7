using Dot.Net.WebApi.Controllers;
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
    public class RuleTest
    {
        [Fact]
        public async Task GetRule()
        {
            //ARRANGE
            var ruleId = 1;
            var mockRepo = new Mock<IRuleRepository>();
            var service = new RuleService(mockRepo.Object);
            mockRepo.Setup(repo => repo.FindByRuleId(It.IsAny<int>()))
                .ReturnsAsync(new RuleModel());
            //ACT
            var rule = await service.GetRule(ruleId);
            //ASSERT
            Assert.IsType<RuleModel>(rule);
            mockRepo.Verify(mock => mock.FindByRuleId(ruleId), Times.Once());
        }
        [Fact]
        public async Task CreateRule()
        {
            //ARRANGE
            var rule = new RuleModel();
            var mockRepo = new Mock<IRuleRepository>();
            var service = new RuleService(mockRepo.Object);
            mockRepo.Setup(repo => repo.CreateRule(It.IsAny<RuleModel>()));
            //ACT
            await service.CreateRule(rule);
            //ASSERT
            mockRepo.Verify(mock => mock.CreateRule(rule), Times.Once());
        }
        [Fact]
        public async Task UpdateRule()
        {
            //ARRANGE
            var rule = new RuleModel();
            var mockRepo = new Mock<IRuleRepository>();
            var service = new RuleService(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateRule(It.IsAny<RuleModel>()));
            //ACT
            await service.UpdateRule(rule);
            //ASSERT
            mockRepo.Verify(mock => mock.UpdateRule(rule), Times.Once());
        }
        [Fact]
        public async Task DeleteRule()
        {
            //ARRANGE
            var ruleId = 1;
            var mockRepo = new Mock<IRuleRepository>();
            var service = new RuleService(mockRepo.Object);
            mockRepo.Setup(repo => repo.DeleteRule(It.IsAny<int>()));
            //ACT
            await service.DeleteRule(1);
            //ASSERT
            mockRepo.Verify(mock => mock.DeleteRule(ruleId), Times.Once());
        }
    }
}
