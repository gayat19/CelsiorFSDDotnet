
using EFCoreFirstAPI.Contexts;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Repositories;
using EFCoreFirstAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest
{
    internal class UserServiceTest
    {
        DbContextOptions options;
        ShoppingContext context;
        UserRepository repository;
        Mock<ILogger<UserRepository>> loggerUserRepo;
        Mock<ILogger<UserService>> loggerUserService;
        Mock<TokenService> mockTokenService;
        Mock<IConfiguration> mockConfiguration;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
            .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            loggerUserRepo = new Mock<ILogger<UserRepository>>();
            loggerUserService = new Mock<ILogger<UserService>>();
            repository = new UserRepository(context, loggerUserRepo.Object);
            mockConfiguration = new Mock<IConfiguration>();
            mockTokenService = new Mock<TokenService>(mockConfiguration.Object);
            mockTokenService.Setup(t => t.GenerateToken(It.IsAny<UserTokenDTO>())).ReturnsAsync("TestToken");

        }

        [Test]
        [TestCase("TestUser2", "TestPassword2", "TestHashKey", Roles.Admin)]
        public async Task TestAdd(string username, string password, string hashKey, Roles role)
        {
            var user = new UserCreateDTO
            {
                Username = username,
                Password = password,
                Role = role
            };
            var userService = new UserService(repository,mockTokenService.Object, loggerUserService.Object);
            var addedUser = await userService.Register(user);
            Assert.IsTrue(addedUser.Username == user.Username);
        }

        [TestCase("TestUser1", "TestPassword1", "TestHashKey1")]
        public async Task TestAuthenticate(string username, string password, string hashKey)
        {
            var user = new UserCreateDTO
            {
                Username = "TestUser1",
                Password = "TestPassword1",
                Role = Roles.Admin
            };
            var userService = new UserService(repository, mockTokenService.Object, loggerUserService.Object);
            var addedUser = await userService.Register(user);
            var loggedInUser = await userService.Autheticate(new LoginRequestDTO
            {
                Username = user.Username,
                Password = user.Password
            });
            Assert.IsTrue(addedUser.Username == loggedInUser.Username);
        }

    }
}
