using FluentValidation;
using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Account
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccount>
    {
        public UpdateAccountValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .Length(8, 50)
                .WithName("Nowe hasło");
            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty()
                .Equal(x => x.NewPassword)
                .WithName("Powtórz nowe hasło");
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .Length(8, 50)
                .WithName("Stare hasło");
        }
    }
}
