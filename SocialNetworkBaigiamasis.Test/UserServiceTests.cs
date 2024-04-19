using Moq;
using SocialNetworkBaigiamasis.DTO;
using SocialNetworkBaigiamasis.Services;
using SocialNetworkBaigiamasis.Models;
using SocialNetworkBaigiamasis.Repositories;
using SocialNetworkBaigiamasis.Exceptions;

namespace SocialNetworkBaigiamasis.Test
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void RegisterWorksWithLongPassword()
        {
            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            UserService service = new UserService(repositoryMock.Object);
            UserCreateDTO user = new UserCreateDTO()
            {
                Username = "12345678",
                Password = "12345678"
            };
            service.Register(user);
            repositoryMock.Verify(x => x.AddUser(Moq.It.IsAny<User>()));
        }

        [TestMethod]
        public void RegisterDoesNotWorkWithshortPassword()
        {
            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            UserService service = new UserService(repositoryMock.Object);
            UserCreateDTO user = new UserCreateDTO()
            {
                Username = "1234",
                Password = "1234"
            };
            var correctExceptionThrown = false;
            try
            {
                service.Register(user);
            }
            catch (ValidationException)
            {
                correctExceptionThrown = true;
            }
            Assert.IsTrue(correctExceptionThrown);
        }
    }
}