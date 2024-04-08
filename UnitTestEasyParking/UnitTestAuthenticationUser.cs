using EasyParking.Api.Controllers;
using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEasyParking
{
    [TestClass]
    public class AuthenticationUserTests
    {
        private Mock<UserService> _userServiceMock;
        private AuthenticationUser _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceMock = new Mock<UserService>();
            _controller = new AuthenticationUser(_userServiceMock.Object);
        }

        [TestMethod]
        public async Task Login_ReturnsOkResult_WhenUserIsAuthenticated()
        {
            // Arrange
            var request = new AuthenticationRequest { Username = "testuser", Password = "testpassword" };
            _userServiceMock.Setup(x => x.AuthenticateAsync(request)).ReturnsAsync(true);

            // Act
            var result = await _controller.Login(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task Login_ReturnsUnauthorizedResult_WhenUserIsNotAuthenticated()
        {
            // Arrange
            var request = new AuthenticationRequest { Username = "testuser", Password = "wrongpassword" };
            _userServiceMock.Setup(x => x.AuthenticateAsync(request)).ReturnsAsync(false);

            // Act
            var result = await _controller.Login(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
            Assert.AreEqual("Tus credenciales no coinciden", ((UnauthorizedObjectResult)result).Value);
        }

        [TestMethod]
        public async Task Login_ReturnsBadRequestResult_WhenRequestIsInvalid()
        {
            // Arrange
            var request = new AuthenticationRequest();

            // Act
            var result = await _controller.Login(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("Por favor, proporcione nombre de usuario y contraseña", ((BadRequestObjectResult)result).Value);
        }
    }

}
