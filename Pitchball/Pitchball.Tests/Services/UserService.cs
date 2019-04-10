using Moq;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Extensions.Interfaces;
using Pitchball.Infrastructure.Services;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Tests.Arrange;
using Pitchball.Tests.Arrange.DataAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Pitchball.Tests.Services
{
    [Collection("User Service Tests")]
    public class UserService : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public UserService(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [CreateUserValidData]
        public void AddAsync_Should_AddUser_When_CorrectDataProvided(CreateAccount command, byte[] expectedPasswordHash, byte[] expectedSalt)
        {
            // Arrange
            var passwordManager = new Mock<IPasswordManager>();
            passwordManager.Setup(p => p.CalculatePasswordHash(It.IsAny<string>(), out expectedPasswordHash, out expectedSalt));
            IUserService userService = new Infrastructure.Services.UserService(fixture.Context, passwordManager.Object);

            // Act
            userService.AddAsync(command);
            var user = fixture.Context.Users.SingleOrDefault(x => x.Id == 1);

            // Assert
            Assert.Equal(command.Name, user.Name);
            Assert.Equal(command.Surname, user.Surname);
            Assert.Equal(command.Login, user.Login);
            Assert.Equal(command.Email, user.Email);
            Assert.Equal(expectedPasswordHash, user.PasswordHash);
            Assert.Equal(expectedSalt, user.Salt);
        }

        [Theory]
        [CreateUserValidData]
        public void AddAsync_Should_ThrowException_When_UserAlreadyExists(CreateAccount command, byte[] expectedPasswordHash, byte[] expectedSalt)
        {
            // Arrange
            var passwordManager = new Mock<IPasswordManager>();
            passwordManager.Setup(p => p.CalculatePasswordHash(It.IsAny<string>(), out expectedPasswordHash, out expectedSalt));
            IUserService userService = new Infrastructure.Services.UserService(fixture.Context, passwordManager.Object);
            fixture.Context.Users.Add(new User(command.Name, command.Surname, command.Login, command.Email, expectedSalt, expectedPasswordHash));
            fixture.Context.SaveChanges();

            // Act and Assert
            Assert.ThrowsAsync<CorruptedOperationException>(() => userService.AddAsync(command));
        }
    }
}
