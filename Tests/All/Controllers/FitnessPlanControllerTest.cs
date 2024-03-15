
// Copilot generated this file. Do not modify this file by hand. Do not remove this file from your project.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyMvcApp.Controllers;
using Xunit;

namespace MyMvcApp.Tests.Controllers
{
    public class FitnessPlanControllerTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly FitnessPlanController _fitnessPlanController;

        public FitnessPlanControllerTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _fitnessPlanController = new FitnessPlanController(_mockHttpClientFactory.Object);
        }

        [Fact]
        public async Task GetFitnessPlan_ReturnsOkResult()
        {
            // Arrange
            var time = 60;
            var equipment = "dumbbells";
            var muscle = "chest";
            var fitnessLevel = "beginner";
            var fitnessGoals = "strength";
            var expectedPlan = "Sample fitness plan";

            var mockHttpClient = new Mock<HttpClient>();
            mockHttpClient
                .Setup(c => c.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedPlan)
                });

            _mockHttpClientFactory
                .Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(mockHttpClient.Object);

            // Act
            var result = await _fitnessPlanController.GetFitnessPlan(time, equipment, muscle, fitnessLevel, fitnessGoals);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var fitnessPlan = Assert.IsType<FitnessPlanViewModel>(okResult.Value);
            Assert.Equal(expectedPlan, fitnessPlan.Plan);
        }
    }
}