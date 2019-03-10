using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Team;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly PitchContext _context;

        public TeamService(PitchContext context)
        {
            _context = context;
        }

        public async Task<Team> AddAsync(CreateTeam command)
        {
            if (await _context.Teams.ExistsInDatabaseAsync(command.Name))
                throw new CorruptedOperationException("Team already exists.");

            var team = new Team(command.Name);

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }
}
