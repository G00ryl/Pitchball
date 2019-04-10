using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Pitchball.Tests.Arrange.DataAttributes
{
    public class CreateUserValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new CreateAccount
                {
                    Name = "Andrey",
                    Surname = "Duck",
                    Login = "TheDuck123",
                    Email = "andrey.duck@gmail.com",
                    Password = "Password123!",
                    ConfirmPassword = "Password123!"
                },
                new byte[] { 0, 1, 2, 3, 4 },
                new byte[] { 4, 3, 2, 1, 0 }
            };
        }
    }
}
