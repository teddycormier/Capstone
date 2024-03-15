
// Copilot generated this file. Do not modify this file by hand. Do not remove this file from your project.

using Capstone.Controllers;
using Capstone.Models;
using Capstone.Models.DbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.DAL;
using Xunit;
using Moq;

namespace Capstone.Tests.Controllers
{
    public class GymPopulationControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithGymPopulations()
        {
            // Arrange
            var dbContext = DbContextMocker.GetGymPopulationDbContext(nameof(Index_ReturnsViewWithGymPopulations));
            var controller = new GymPopulationController(dbContext);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<GymPopulationViewModel>>(viewResult.Model);
            Assert.Equal(dbContext.GymPopulations.Count(), model.Count());
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenGymPopulationsIsNull()
        {
            // Arrange
            var dbContext = DbContextMocker.GetGymPopulationDbContext(nameof(Index_ReturnsEmptyView_WhenGymPopulationsIsNull));
            dbContext.GymPopulations = null; // Simulate null database result
            var controller = new GymPopulationController(dbContext);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<GymPopulationViewModel>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Dashboard_ReturnsViewWithGymPopulations()
        {
            // Arrange
            var dbContext = DbContextMocker.GetGymPopulationDbContext(nameof(Dashboard_ReturnsViewWithGymPopulations));
            var controller = new GymPopulationController(dbContext);

            // Act
            var result = controller.Dashboard();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<GymPopulationViewModel>>(viewResult.Model);
            Assert.Equal(dbContext.GymPopulations.Count(), model.Count());
        }

        [Fact]
        public void Dashboard_ReturnsEmptyView_WhenGymPopulationsIsNull()
        {
            // Arrange
            var dbContext = DbContextMocker.GetGymPopulationDbContext(nameof(Dashboard_ReturnsEmptyView_WhenGymPopulationsIsNull));
            dbContext.GymPopulations = null; // Simulate null database result
            var controller = new GymPopulationController(dbContext);

            // Act
            var result = controller.Dashboard();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<GymPopulationViewModel>>(viewResult.Model);
            Assert.Empty(model);
        }
    }

    public static class DbContextMocker
    {
        public static GymPopulationDbContext GetGymPopulationDbContext(string dbName)
        {
            // Create mock DbSet and mock DbContext
            var gymPopulations = new List<GymPopulation>
            {
                new GymPopulation { Id = 1, Monday = 10, Tuesday = 20, Wednesday = 30, Thursday = 40, Friday = 50, Saturday = 60, Sunday = 70 },
                new GymPopulation { Id = 2, Monday = 15, Tuesday = 25, Wednesday = 35, Thursday = 45, Friday = 55, Saturday = 65, Sunday = 75 }
            };

            var mockDbSet = new Mock<DbSet<GymPopulation>>();
            mockDbSet.As<IQueryable<GymPopulation>>().Setup(m => m.Provider).Returns(gymPopulations.AsQueryable().Provider);
            mockDbSet.As<IQueryable<GymPopulation>>().Setup(m => m.Expression).Returns(gymPopulations.AsQueryable().Expression);
            mockDbSet.As<IQueryable<GymPopulation>>().Setup(m => m.ElementType).Returns(gymPopulations.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<GymPopulation>>().Setup(m => m.GetEnumerator()).Returns(gymPopulations.GetEnumerator());

            var mockDbContext = new Mock<GymPopulationDbContext>();
            mockDbContext.Setup(c => c.GymPopulations).Returns(mockDbSet.Object);

            return mockDbContext.Object;
        }
    }
}
