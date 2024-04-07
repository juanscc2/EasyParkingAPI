using EasyParking.Api.Controllers;
using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Data.DTOS.Response;
using EasyParking.Api.Data.Models;
using EasyParking.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTestEasyParking
{
    [TestClass]
    public class UnitTestUser
    {
        private Mock<UserService> _userServiceMock;
        private UserController _userController;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceMock = new Mock<UserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [TestMethod]
        public async Task GetUsers_ReturnsOkResult_WhenUsersAreRetrievedSuccessfully()
        {
            // Arrange
            var userDTOs = new List<UserResponse>
        {
            new UserResponse { id = 1, username = "user1", email = "user1@example.com", name = "User 1" },
            new UserResponse { id = 2, username = "user2", email = "user2@example.com", name = "User 2" },
        };
            _userServiceMock.Setup(x => x.GetUsersAsync()).ReturnsAsync(userDTOs);

            // Act
            var result = await _userController.GetUsers();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<UserResponse>));
            var userList = okResult.Value as List<UserResponse>;
            Assert.AreEqual(userDTOs.Count, userList.Count);
            for (int i = 0; i < userDTOs.Count; i++)
            {
                Assert.AreEqual(userDTOs[i].id, userList[i].id);
                Assert.AreEqual(userDTOs[i].username, userList[i].username);
                Assert.AreEqual(userDTOs[i].email, userList[i].email);
                Assert.AreEqual(userDTOs[i].name, userList[i].name);
            }
        }

        [TestMethod]
        public async Task CreateUser_ReturnsOkResult_WhenUserIsCreatedSuccessfully()
        {
            // Arrange
            var userDTO = new UserRequest { username = "user1", email = "user1@example.com", name = "User 1", password = "password1" };
            _userServiceMock.Setup(x => x.CreateUserASync(userDTO)).ReturnsAsync(true);

            // Act
            var result = await _userController.CreateUser(userDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Usuario creado exitosamente", okResult.Value);
        }

        [TestMethod]
        public async Task CreateUser_ReturnsBadRequestResult_WhenUserCreationFails()
        {
            // Arrange
            var userDTO = new UserRequest { username = "user1", email = "user1@example.com", name = "User 1", password = "password1" };
            _userServiceMock.Setup(x => x.CreateUserASync(userDTO)).ReturnsAsync(false);

            // Act
            var result = await _userController.CreateUser(userDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("El usuario no pudo ser creado", badRequestResult.Value);
        }
        [TestMethod]
        public async Task UpdateUser_ReturnsOkResult_WhenUserIsUpdatedSuccessfully()
        {
            // Arrange
            var updateUserRequest = new UpdateUserRequest { UserName = "newUsername", Email = "newEmail@example.com", Name = "newName" };
            var updatedUser = new User { Id = 1, Username = "newUsername", Email = "newEmail@example.com", Name = "newName" };
            _userServiceMock.Setup(x => x.UpdateUserAsync(1, updateUserRequest)).ReturnsAsync(updatedUser);

            // Act
            var result = await _userController.UpdateUser(1, updateUserRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            var updatedUserDTO = okResult.Value as UserResponse;
            Assert.IsNotNull(updatedUserDTO);
            Assert.AreEqual(updatedUser.Username, updatedUser.Username);
            Assert.AreEqual(updatedUser.Email, updatedUser.Email);
            Assert.AreEqual(updatedUser.Name, updatedUser.Name);
        }

        [TestMethod]
        public async Task UpdateUser_ReturnsNotFoundResult_WhenUserIsNotFound()
        {
            // Arrange
            var updateUserRequest = new UpdateUserRequest { UserName = "newUsername", Email = "newEmail@example.com", Name = "newName",Password= "NewPassWord" };
            _userServiceMock.Setup(x => x.UpdateUserAsync(1, updateUserRequest)).ThrowsAsync(new Exception("User not found"));

            // Act
            var result = await _userController.UpdateUser(1, updateUserRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task UpdateUser_ReturnsBadRequestResult_WhenUpdateUserRequestIsInvalid()
        {
            // Arrange
            var updateUserRequest = new UpdateUserRequest { UserName = "", Email = "", Name = "" ,Password=""};

            // Act
            var result = await _userController.UpdateUser(1, updateUserRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult.Value);
            Assert.AreEqual("El usuario no pudo ser actualizado", badRequestResult.Value);
        }
    }
    }
