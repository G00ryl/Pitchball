using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Account;
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
    public class UserService : IUserService
    {
        private readonly PitchContext _context;
        private readonly IPasswordManager _passwordManager;

        public UserService(PitchContext context, IPasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }

        public async Task AddAsync(CreateAccount command)
        {
            byte[] salt, passwordHash;

            if (await _context.Accounts.ExistsInDatabaseAsync(command.Login, command.Email))
                throw new CorruptedOperationException("User already exists.");

            _passwordManager.CalculatePasswordHash(command.Password, out passwordHash, out salt);

            var user = new User(command.Name, command.Surname, command.Login, command.Email, salt, passwordHash);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
