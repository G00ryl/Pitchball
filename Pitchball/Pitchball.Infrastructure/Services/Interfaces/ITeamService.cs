using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Team;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface ITeamService
    {
        Task<Team> AddAsync(CreateTeam command);
    }
}
