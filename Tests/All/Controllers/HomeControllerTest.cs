
// Copilot generated this file. Do not modify this file by hand. Do not remove this file from your project.

using Microsoft.AspNetCore.Mvc;
using Moq;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using Xunit;

namespace MyMvcApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly HomeController _homeController;

        public HomeControllerTests()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _homeController = new HomeController(_mockLogger.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void FitnessPlan_ReturnsViewResult()
        {
            // Act
            var result = _homeController.FitnessPlan();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Dashboard_ReturnsViewResult()
        {
            // Act
            var result = _homeController.Dashboard();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("~/Views/GymPopulation/Index.cshtml", viewResult.ViewName);
        }

        [Fact]
        public void UserProfile_ReturnsViewResult()
        {
            // Act
            var result = _homeController.UserProfile();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Calendar_ReturnsViewResult()
        {
            // Act
            var result = _homeController.Calendar();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void DB_ReturnsViewResult()
        {
            // Act
            var result = _homeController.DB();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Error_ReturnsViewResult()
        {
            // Act
            var result = _homeController.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var errorViewModel = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.NotNull(errorViewModel.RequestId);
        }
    }
}