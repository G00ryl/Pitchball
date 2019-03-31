using FluentValidation;
using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Account
{
    public class LoginAccountValidator : AbstractValidator<LoginAccount>
    {
        public LoginAccountValidator()
        {
            RuleFor(x => x.LoginOrEmail)
                .NotEmpty()
                .MinimumLength(5)
                .WithName("Login/Email");
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 50)
                .WithName("Hasło");
        }
    }
}
