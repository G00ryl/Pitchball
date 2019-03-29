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

        }
    }
}
