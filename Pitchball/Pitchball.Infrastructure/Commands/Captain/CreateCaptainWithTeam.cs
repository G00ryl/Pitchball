using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Captain
{
    public class CreateCaptainWithTeam : CreateAccount
    {
        public CreateTeam Team { get; set; }
    }
}
