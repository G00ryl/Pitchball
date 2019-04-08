using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Services;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Tests.Arrange;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pitchball.Tests.Services
{
    [Collection("User Service Tests")]
    public class UserServiceShould : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public UserServiceShould(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddUser_When_CorrectDataProvided()
        {
            // need to mock PasswordManager first
            // IUserService userService = new UserService(fixture.Context)
        }
    }
}
