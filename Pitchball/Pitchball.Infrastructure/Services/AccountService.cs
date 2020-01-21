using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Extensions.Interfaces;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.Data.QueryExtenions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pitchball.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly PitchContext _context;
        private readonly IPasswordManager _passwordManager;

        public AccountService(PitchContext context, IPasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }

        public async Task<Account> LoginAsync(LoginAccount command)
        {
            var account = await _context.Accounts.GetByLoginOrEmail(command.LoginOrEmail).SingleOrDefaultAsync();

            if (account == null)
                throw new CorruptedOperationException("Account doesn't exist");

            var isPasswordCorrect = _passwordManager.VerifyPasswordHash(command.Password, account.PasswordHash, account.Salt);

            if (isPasswordCorrect == false)
                throw new CorruptedOperationException("Wrong credentials");

            return account;
        }

        public async Task<Account> GetAsync(int id)
        {
            var account = await _context.Accounts.GetById(id).Include(x=>x.Messages).SingleOrDefaultAsync();

            if (account == null)
                throw new CorruptedOperationException("Account doesn't exist");

            return account;
        }

        public async Task ChangePasswordAsync(int id, UpdateAccount command)
        {
            var account = await GetAsync(id);

            _passwordManager.CalculatePasswordHash(command.NewPassword, out byte[] passwordHash, account.Salt);

            account.Update(account.Name, account.Surname, passwordHash);

            await _context.SaveChangesAsync();
        }
    }
}
