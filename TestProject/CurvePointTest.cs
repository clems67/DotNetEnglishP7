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
    public class CurvePointTest
    {
        [Fact]
        public async Task GetCurvePoint()
        {
            //ARRANGE
            var curvepointId = 1;
            var mockRepo = new Mock<ICurvePointRepository>();
            var service = new CurvePointService(mockRepo.Object);
            mockRepo.Setup(repo => repo.FindByCurvePointId(It.IsAny<int>()))
                .ReturnsAsync(new CurvePointModel());
            //ACT
            var curvepoint = await service.GetCurvePoint(curvepointId);
            //ASSERT
            Assert.IsType<CurvePointModel>(curvepoint);
            mockRepo.Verify(mock => mock.FindByCurvePointId(curvepointId), Times.Once());
        }
        [Fact]
        public async Task CreateCurvePoint()
        {
            //ARRANGE
            var curvepoint = new CurvePointModel();
            var mockRepo = new Mock<ICurvePointRepository>();
            var service = new CurvePointService(mockRepo.Object);
            mockRepo.Setup(repo => repo.CreateCurvePoint(It.IsAny<CurvePointModel>()));
            //ACT
            await service.CreateCurvePoint(curvepoint);
            //ASSERT
            mockRepo.Verify(mock => mock.CreateCurvePoint(curvepoint), Times.Once());
        }
        [Fact]
        public async Task UpdateCurvePoint()
        {
            //ARRANGE
            var curvepoint = new CurvePointModel();
            var mockRepo = new Mock<ICurvePointRepository>();
            var service = new CurvePointService(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateCurvePoint(It.IsAny<CurvePointModel>()));
            //ACT
            await service.UpdateCurvePoint(curvepoint);
            //ASSERT
            mockRepo.Verify(mock => mock.UpdateCurvePoint(curvepoint), Times.Once());
        }
        [Fact]
        public async Task DeleteCurvePoint()
        {
            //ARRANGE
            var curvepointId = 1;
            var mockRepo = new Mock<ICurvePointRepository>();
            var service = new CurvePointService(mockRepo.Object);
            mockRepo.Setup(repo => repo.DeleteCurvePoint(It.IsAny<int>()));
            //ACT
            await service.DeleteCurvePoint(1);
            //ASSERT
            mockRepo.Verify(mock => mock.DeleteCurvePoint(curvepointId), Times.Once());
        }
    }
}
