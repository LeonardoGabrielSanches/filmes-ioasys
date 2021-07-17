using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Enums;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Services.Users;
using NSubstitute;

namespace MoviesIoasys.Domain.Tests.Users
{
    [TestClass]
    public class CreateUserTests
    {
        private const string
            email = "email@email.com",
            password = "password",
            name = "name",
            invalidEmail = "",
            invalidPassword = "",
            invalidName = "";

        private const UserRole
            Admin = UserRole.Admin;

        private readonly IUsersRepository _usersRepository;

        public CreateUserTests()
        {
            _usersRepository = Substitute.For<IUsersRepository>();
        }

        private CreateUserService CreateUserService
            => new CreateUserService(_usersRepository);

        private CreateUserDTO InvalidUserDTO
            => new CreateUserDTO(email: invalidEmail,
                                 password: invalidPassword,
                                 name: invalidName,
                                 userRole: Admin);

        private CreateUserDTO UserDTO
            => new CreateUserDTO(email: email,
                                 password: password,
                                 name: name,
                                 userRole: Admin);

        private User User
            => new User(email: email,
                        password: password,
                        name: name,
                        userRole: Admin);

        [TestMethod]
        public void Service_ReturnsInvalidEntity_IfUserIsNotValid()
        {
            var createdUser = CreateUserService.CreateUser(InvalidUserDTO);

            Assert.IsFalse(createdUser.IsValid);
        }

        [TestMethod]
        public void Service_ReturnsInvalidEntity_IfEmailAlreadyExists()
        {
            _usersRepository.GetUserByEmail(UserDTO.Email).Returns(User);

            var createdUser = CreateUserService.CreateUser(UserDTO);

            Assert.IsFalse(createdUser.IsValid);
        }

        [TestMethod]
        public void Service_ReturnsEntity_IfUserCreated()
        {
            _usersRepository.GetUserByEmail(UserDTO.Email).Returns(new User());

            var createdUser = CreateUserService.CreateUser(UserDTO);

            Assert.AreEqual(createdUser.Email, UserDTO.Email);
            Assert.AreEqual(createdUser.Name, UserDTO.Name);
            Assert.AreEqual(createdUser.UserRole, UserDTO.UserRole);
            Assert.AreEqual(createdUser.Active, true);
        }
    }
}
