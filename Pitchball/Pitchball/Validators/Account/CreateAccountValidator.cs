using FluentValidation;
using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Account
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 80)
                .WithName("Imię");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .Length(2, 80)
                .WithName("Nazwisko");
            RuleFor(x => x.Login)
                .NotEmpty()
                .Length(5, 50);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 50)
                .WithName("Hasło");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithName("Powtórz hasło");
        }
    }
}
