using FluentValidation;
using Pitchball.Infrastructure.Commands.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Team
{
    public class CreateTeamValidator : AbstractValidator<CreateTeam>
    {
        public CreateTeamValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithName("Nazwa drużyny");
        }
    }
}
