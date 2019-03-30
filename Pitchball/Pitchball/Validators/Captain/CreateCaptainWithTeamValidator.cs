using FluentValidation;
using Pitchball.Infrastructure.Commands.Captain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Captain
{
    public class CreateCaptainWithTeamValidator : AbstractValidator<CreateCaptainWithTeam>
    {
        public CreateCaptainWithTeamValidator()
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
            RuleFor(x => x.Team.Name)
                .NotEmpty()
                .Length(5, 150)
                .WithName("Nazwa drużyny");
        }
    }
}
