using Microsoft.AspNetCore.Mvc;
using Moq;
using Capstone.Controllers;
using Capstone.Models;
using Xunit;
using Capstone.ViewModels;

namespace Capstone.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userController = new UserController();
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _userController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Details_ReturnsViewResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = _userController.Details(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Edit_GET_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            using Capstone.Models; // Add the missing using directive for the 'User' class

            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };
            _mockUserRepository.Setup(repo => repo.GetUserById(id)).Returns(user);

            // Act
            var result = _userController.Edit(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var userViewModel = Assert.IsType<UserViewModel>(viewResult.Model);
            Assert.Equal(user.FirstName, userViewModel.FirstName);
            Assert.Equal(user.LastName, userViewModel.LastName);
            Assert.Equal(user.Email, userViewModel.Email);
        }

        [Fact]
        public void Edit_POST_ValidModel_RedirectsToDetails()
        {
            // Arrange
            int id = 1;
            var userViewModel = new UserViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            _mockUserRepository.Setup(repo => repo.GetUserById(id)).Returns(user);

            // Act
            var result = _userController.Edit(id, userViewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal(id, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public void Edit_POST_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            var userViewModel = new UserViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = null // Invalid model state
            };

            // Act
            var result = _userController.Edit(id, userViewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(userViewModel, viewResult.Model);
        }

        [Fact]
        public void Delete_ReturnsViewResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = _userController.Delete(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex()
        {
            // Arrange
            int id = 1;

            // Act
            var result = _userController.DeleteConfirmed(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }

    internal interface IUserRepository
    {
    }
}