using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Extensions.Interfaces;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class CaptainService : ICaptainService
    {
        private readonly PitchContext _context;
        private readonly IPasswordManager _passwordManager;
        private readonly ITeamService _teamService;

        public CaptainService(PitchContext context, IPasswordManager passwordManager, ITeamService teamService)
        {
            _context = context;
            _passwordManager = passwordManager;
            _teamService = teamService;
        }

        public async Task AddWIthTeamAsync(CreateCaptainWithTeam command)
        {
            byte[] salt, passwordHash;

            var team = await _teamService.AddAsync(command.Team);

            if (await _context.Accounts.ExistsInDatabaseAsync(command.Login, command.Email))
                throw new CorruptedOperationException("Captain already exists.");

            _passwordManager.CalculatePasswordHash(command.Password, out passwordHash, out salt);

            var captain = new Captain(command.Name, command.Surname, command.Login, command.Email, salt, passwordHash);
            team.Captain = captain;

            await _context.Captains.AddAsync(captain);
            await _context.SaveChangesAsync();
        }

        public async Task<Captain> GetAsync(int id)
        {
            var captain = await _context.Captains.GetById(id).Include(x => x.AccountImage).Include(x => x.Reservations).ThenInclude(y => y.Pitch).Include(x => x.Team).SingleOrDefaultAsync();

            if (captain == null)
                throw new CorruptedOperationException("Captain doesn't exist");

            return captain;
        }
    }
}
